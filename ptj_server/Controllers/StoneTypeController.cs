using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoneTypeController : Controller
    {
        private readonly IBaseRepository<StoneType> _baseStoneType;

        public StoneTypeController(IBaseRepository<StoneType> baseStoneType)
        {
            _baseStoneType = baseStoneType;
        }

        [Produces("application/json")]
        [HttpGet("findAllStoneType")]
        public async Task<ActionResult<IEnumerable<StoneType>>> findAllStoneType()
        {
            try
            {
                return Ok(await _baseStoneType.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

