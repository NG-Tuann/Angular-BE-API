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
using ptj_server.Paypal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : Controller
    {
        public IConfiguration configuration { get; }
        private readonly IBaseRepository<OrderProduct> _baseOrderProduct;
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IConfiguration _configuration, IOrderProductService orderProductService, IBaseRepository<OrderProduct> baseOrderProduct)
        {
            configuration = _configuration;
            _orderProductService = orderProductService;
            _baseOrderProduct = baseOrderProduct;
        }

        // GET: /<controller>/
        [HttpGet("checkout/{total}")]
        [Produces("application/json")]
        public async Task<ActionResult<String>> CheckOut(double total)
        {
            var payPalAPI = new PayPalAPI(configuration);
            string url = await payPalAPI.getRedirectURLToPayPal(total, "USD");
            return url;
        }

        [HttpGet("trackOrder/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<OrderProduct>> trackOrder(string id)
        {
            try
            {
                return Ok(await _baseOrderProduct.Entities
                    .Include( i => i.OrderDetails)
                        .ThenInclude(x => x.ProductDetail)
                        .ThenInclude(z => z.Product)
                    .FirstOrDefaultAsync(i => i.OrderProductId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("nonCustomerPaypalSuccess")]
        public async Task<ActionResult<String>> NonCustomerPaypalSuccess(NonCustomerPaypalSuccess result)
        {
            // Thuc hien luu don hang vao csdl
            // Goi service thuc hien
            // Service bao gom luu db va gui ma don hang qua mail cho khach
            var msg = _orderProductService.processNonCustomerPaypalSuccess(result);
            return Ok(msg);
        }
    }
}

