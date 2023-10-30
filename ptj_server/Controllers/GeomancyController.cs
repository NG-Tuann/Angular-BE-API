using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeomancyController : Controller
    {
        private readonly IBaseRepository<Geomancy> _baseGeomancy;

        public GeomancyController(IBaseRepository<Geomancy> baseGeomancy)
        {
            _baseGeomancy = baseGeomancy;
        }

        // GET: /<controller>/
        [Produces("application/json")]
        [HttpGet("findAllGeomancy")]
        public async Task<ActionResult<IEnumerable<Geomancy>>> findAllGeomancy()
        {
            try
            {
                return Ok(await _baseGeomancy.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}

