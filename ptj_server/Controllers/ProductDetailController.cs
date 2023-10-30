using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptj_server.Dtos;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : Controller
    {
        private readonly IBaseRepository<Product> _baseProduct;
        private readonly IBaseRepository<ProductPrice> _baseProductPrice;
        private readonly IBaseRepository<ProductDetail> _baseProductDetail;

        public ProductDetailController(IBaseRepository<Product> baseProduct
            , IBaseRepository<ProductPrice> baseProductPrice
            , IBaseRepository<ProductDetail> baseProductDetail)
        {
            _baseProduct = baseProduct;
            _baseProductPrice = baseProductPrice;
            _baseProductDetail = baseProductDetail;
        }

        [Produces("application/json")]
        [HttpGet("findProductDetailById/{id}")]
        public async Task<ActionResult<Product>> findProductDetailById(int id)
        {

            try
            {
                var product = await _baseProduct.Entities
                    .Include(i => i.ProductDetails.OrderBy(x => x.Size))
                        .ThenInclude(pd => pd.ProductPrice)
                    .Include(i => i.Cat)
                    .Include(i => i.MainStone)
                    .Include(i => i.SubStone)
                    .Include(i => i.Geomancy)
                    .Include(i => i.Images)
                    .Include(i => i.ProductDiscounts.OrderByDescending(d => d.DateCreated).Take(1))
                    .SingleOrDefaultAsync(i => i.Id == id);
               
                return product;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<ActionResult<ProductDetail[]>> create([FromBody] ProductDetailDTO pd)
        {

            try
            {
                // Them moi product price cho product detail
                var productPrice = new ProductPrice();
                productPrice.SalePrice = (int)pd.ProductPrice.SalePrice;
                productPrice.BasePrice = (int)pd.ProductPrice.BasePrice;
                productPrice.CreatedDate = pd.CreatedDate;
                productPrice.InActive = true;

                await _baseProductPrice.AddAsync(productPrice);

                // Them moi productDetail
                var productDetail = new ProductDetail();
                productDetail.ProductId = pd.Product.Id;
                productDetail.Quantity = pd.Quantity;
                productDetail.ImportQuantity = pd.ImportQuantity;
                productDetail.ProductPriceId = productPrice.Id;
                productDetail.CreatedDate = pd.CreatedDate;
                productDetail.Size = (int)pd.Size;

                await _baseProductDetail.AddAsync(productDetail);

                return Ok(await _baseProductDetail.Entities.Include(i => i.ProductPrice).Where(i => i.ProductId == pd.Product.Id).ToListAsync());

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}

