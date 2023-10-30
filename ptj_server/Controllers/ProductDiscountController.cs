using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDiscountController : Controller
    {
        private readonly IBaseRepository<ProductDiscount> _baseProductDiscount;

        public ProductDiscountController(IBaseRepository<ProductDiscount> baseProductDiscount)
        {
            _baseProductDiscount = baseProductDiscount;
        }

        [Produces("application/json")]
        [HttpGet("findAllProductDiscount")]
        public async Task<ActionResult<IEnumerable<ProductDiscount>>> findAllProductDiscount()
        {
            try
            {
                return Ok(await _baseProductDiscount.Entities.Include(i => i.Product).ToListAsync());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}

