using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    public class CategoryProductController : Controller
    {
        private readonly IBaseRepository<CategoryProduct> _baseCategoryProduct;

        public CategoryProductController(IBaseRepository<CategoryProduct> baseCategoryProduct)
        {
            _baseCategoryProduct = baseCategoryProduct;
        }

        [Produces("application/json")]
        [HttpGet("findAllCategoryProduct")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> findAllCategoryProduct()
        {
            try
            {
                return Ok(await _baseCategoryProduct.GetAllAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAllNonParentCategoryProduct")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> findAllNonParentCategoryProduct()
        {
            try
            {
                return Ok(await _baseCategoryProduct.Entities.Where(i => i.ParentId != null).ToListAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAllCategoryProductByParentId/{id}")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> findAllCategoryProductByParentId(int id)
        {
            try
            {
                return Ok(await _baseCategoryProduct.GetListByAsync(i => i.ParentId == id));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> create([FromBody] CategoryProductDTO categoryProduct)
        {
            try
            {
                var categoryDb = new CategoryProduct();
                categoryDb.Name = categoryProduct.Name;
                if(categoryProduct.ParentId >0 || categoryProduct.ParentId!=null )
                {
                    categoryDb.ParentId = categoryProduct.ParentId;
                }

                await _baseCategoryProduct.AddAsync(categoryDb);

                return Ok(await _baseCategoryProduct.GetAllAsync());
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> delete(int id)
        {
            try
            {
                var categoryProductDb = await _baseCategoryProduct.GetByIdAsync(id);

                if (categoryProductDb == null)
                    return NotFound();

                await _baseCategoryProduct.DeleteAsync(categoryProductDb.Id);

                return Ok(await _baseCategoryProduct.GetAllAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }


    }
}

