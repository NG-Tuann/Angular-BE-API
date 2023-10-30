using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ptj_server.Dtos;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IBaseRepository<Role> _baseRole;
        public RoleController(IBaseRepository<Role> baseRole)
        {
            _baseRole = baseRole;
        }

        [Produces("application/json")]
        [HttpGet("findAllRole")]
        public async Task<ActionResult<IEnumerable<Role>>> findAllRole()
        {
            try
            {
                return Ok(await _baseRole.GetAllAsync());
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<Role>>> create([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var role = new Role()
                {
                    Name = roleDTO.Name
                };

                await _baseRole.AddAsync(role);

                return Ok(await _baseRole.GetAllAsync());
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<Role>>> delete(int id)
        {
            try
            {
                var role = await _baseRole.GetByIdAsync(id);

                if (role == null)
                    return NotFound();

                await _baseRole.DeleteAsync(id);

                return Ok(await _baseRole.GetAllAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<ActionResult<IEnumerable<Role>>> update([FromBody] RoleDTO role)
        {
            try
            {
                var dbRole = await _baseRole.GetByIdAsync(role.Id);

                if (dbRole == null)
                    return NotFound();

                dbRole.Name = role.Name;

                await _baseRole.UpdateAsync(dbRole);
                return Ok(await _baseRole.GetAllAsync());

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}

