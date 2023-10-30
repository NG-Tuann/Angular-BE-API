using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptj_server.Dtos;
using ptj_server.Interfaces;
using ptj_server.Models;
using ptj_server.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Image = ptj_server.Models.Image;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // !IMPORTANT
        private readonly IBaseRepository<Product> _baseProduct;
        private readonly IBaseRepository<Image> _baseImage;
        private readonly IProductService _productService;

        public ProductController(IWebHostEnvironment webHostEnvironment, IBaseRepository<Product> baseProduct,
            IHttpContextAccessor _httpContextAccessor, IBaseRepository<Image> baseImage, IProductService productService)
        {
            _webHostEnvironment = webHostEnvironment;
            _baseProduct = baseProduct;
            _baseImage = baseImage;
            _productService = productService;
        }

        [Produces("application/json")]
        [HttpGet("findAllProduct"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<dynamic>>> findAllProduct()
        {
            try
            {

                return Ok(await findAllProducts());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findProductById/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<dynamic>>> findProductById(int id)
        {
            try
            {
                return Ok(await _baseProduct.Entities.Include(i => i.ProductDetails).ThenInclude(i => i.ProductPrice).SingleOrDefaultAsync(i => i.Id == id));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAllProductDisplay")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> findAllProductDisplay()
        {
            try
            {
                
                return Ok(await _productService.findAllActiveProduct());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAllProductHomeFlagDisplay")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> findAllProductHomeFlagDisplay()
        {
            try
            {

                return Ok(await _productService.findAllHomeFlagProduct());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAllBestSellerProductDisplay")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> findAllBestSellerProductDisplay()
        {
            try
            {

                return Ok(await _productService.findAllBestSellerProduct());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> delete(int id)
        {
            try
            {
                var productDb = await _baseProduct.GetByIdAsync(id);
                if(productDb !=null)
                {
                    await _baseProduct.DeleteAsync(productDb.Id);
                    return Ok(await findAllProducts());
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // GET: /<controller>/
        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [DisableRequestSizeLimit]
        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<dynamic>>> create([FromForm] ProductDTO product)
        {
            try
            {
                // Tra ve danh sach san pham sau khi them
                var productDb = new Product();
                productDb.Active = false;
                productDb.BestSeller = false;
                productDb.HomeFlag = false;
                productDb.CatId = product.CatId;
                productDb.Color = product.Color;
                productDb.GeomancyId = product.GeomancyId;
                productDb.MainStoneId = product.MainStoneId;
                productDb.Name = product.Name;
                productDb.Note = product.Note;
                productDb.SubStoneId = product.SubStoneId;

                // Them hinh anh dai dien cho san pham
                if (product.File != null)
                {
                    var newFileName = Helpers.FileHelper.GenerateFileName(product.File.ContentType);
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "img_products", newFileName);
                    using (var fileStream = new FileStream(path, FileMode.Create)) // !IMPORTANT
                    {
                        // upload file vao fileStream
                        await product.File.CopyToAsync(fileStream);
                    }
                    productDb.Image = newFileName;
                }

                // Thuc hien luu db san pham
                await _baseProduct.AddAsync(productDb);

                // Them hinh anh mo ta cho san pham

                if (product.Files != null)
                {
                    foreach (var file in product.Files)
                    {
                        var newFileName = Helpers.FileHelper.GenerateFileName(file.ContentType);
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, "img_products", newFileName);
                        using (var fileStream = new FileStream(path, FileMode.Create)) // !IMPORTANT
                        {
                            // upload file vao fileStream
                            await file.CopyToAsync(fileStream);
                        }
                        //productDb.Image = newFileName;

                        var img = new Image();
                        img.NameImages = newFileName;
                        img.IdProduct = productDb.Id;

                        await _baseImage.AddAsync(img);
                    }
                }

                return Ok(await findAllProducts());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // Findallproducts
        private async Task<dynamic> findAllProducts()
        {
            return await _baseProduct.Entities.Select(i => new
            {
                id = i.Id,
                name = i.Name,
                geomancy = i.Geomancy,
                image = "http://localhost:5275/" + "img_products/" + i.Image,
                color = i.Color,
                note = i.Note,
                bestSeller = i.BestSeller,
                homeFlag = i.HomeFlag,
                active = i.Active,
                cat = i.Cat,
                mainStone = i.MainStone,
                subStone = i.SubStone
            }).OrderByDescending(i => i.id).ToListAsync();
        }

        // Update homeflag, bestseller, active

        [Produces("application/json")]
        [HttpPut("updateHomeFlag/{id}")]
        public async Task<IActionResult> UpdateHomeFLag(int id)
        {
            try
            {
                var productDb = await _baseProduct.GetByIdAsync(id);

                if (productDb != null && productDb.Id > 0)
                {
                    productDb.HomeFlag = !productDb.HomeFlag;
                    await _baseProduct.UpdateAsync(productDb);
                    return Ok("Update success");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpPut("updateActive/{id}")]
        public async Task<IActionResult> updateActive(int id)
        {
            try
            {
                var productDb = await _baseProduct.GetByIdAsync(id);

                if (productDb != null && productDb.Id > 0)
                {
                    productDb.Active = !productDb.Active;
                    await _baseProduct.UpdateAsync(productDb);
                    return Ok("Update success");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpPut("updateBestSeller/{id}")]
        public async Task<IActionResult> updateBestSeller(int id)
        {
            try
            {
                var productDb = await _baseProduct.GetByIdAsync(id);

                if (productDb != null && productDb.Id > 0)
                {
                    productDb.BestSeller = !productDb.BestSeller;
                    await _baseProduct.UpdateAsync(productDb);
                    return Ok("Update success");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}

