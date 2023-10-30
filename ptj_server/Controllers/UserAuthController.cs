using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ptj_server.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ptj_server.DatabaseContext;
using ptj_server.Dtos;
using ptj_server.Interfaces;
using ptj_server.Models;

namespace ptj_server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAuthController : Controller
{
    private readonly IBaseRepository<User> _baseUser;
    private readonly IBaseRepository<Role> _baseRole;
    private readonly DataContext _db;
    private readonly IConfiguration _configuration;

    public UserAuthController(IBaseRepository<User> baseUser, IBaseRepository<Role> baseRole, DataContext db, IConfiguration configuration)
    {
        _baseUser = baseUser;
        _baseRole = baseRole;
        _db = db;
        _configuration = configuration;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("register"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<User>>> Register([FromBody] UserDTO request)
    {
        try
        {
            // Kiem tra username ton tai
            var existUsr = await _baseUser.GetByAsync(i => i.Username.Equals(request.Username));

            if(existUsr !=null && existUsr.Id >0)
                return BadRequest("User exist");

            // Tim ve role tuong ung voi id
            var role = await _baseRole.GetByIdAsync(request.IdRole);

            if (role == null)
                return NotFound();

            // Gui mail otp cho nhan vien kich hoat tai khoan gom 6 so
            Random rnd = new Random();

            var randomPassword = rnd.Next(100000, 999999);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword.ToString());

            var user = new User
            {
                Username = request.Username,
                Dob = request.Dob,
                Fullname = request.Fullname,
                IdCard = request.IdCard,
                IdRole = request.IdRole,
                Role = role,
                Password = passwordHash,
                Phone = request.Phone
            };

            await _baseUser.AddAsync(user);

            var mailHelper = new MailHelper(_configuration);
            string subject = "Mail gửi với mục đích kích hoạt tài khoản và thông tin về mật khẩu";
            string content = "Sau khi nhận mật khẩu hãy đăng nhập và thay đổi mật khẩu. Mật khẩu của bạn là: " + randomPassword;
            if (await mailHelper.Send("tuan.ng400@aptechlearning.edu.vn", user.Username, subject, content))
            {
                Debug.WriteLine("Send mail success");
            }
            else
            {
                Debug.WriteLine("Send mail fail");
            }

            return Ok(await _baseUser.Entities.Include(i => i.Role).OrderByDescending(i => i.Id).ToListAsync());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginModel model)
    {
        try
        {
            var usrs = await _db.Users.Include(i => i.Role).ToListAsync();

            var validUser = usrs.SingleOrDefault(i => i.Username.Equals(model.Username));

            if(validUser == null)
            {
                return Ok("invalid_user");
            }

            if(!BCrypt.Net.BCrypt.Verify(model.Password, validUser.Password))
            {
                return Ok("invalid_password");
            }

            var jwtHelper = new JwtHelper(_configuration);
            var token = jwtHelper.CreateUserJwtToken(validUser.Username, validUser.Id.ToString(), validUser.Fullname, validUser.Role.Name);

            return Ok(token);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest("fail");
        }
    }

    [Produces("application/json")]
    [HttpGet("findAllUserByRole/{id}")]
    public async Task<ActionResult<IEnumerable<User>>> findAllUserByRole(int id)
    {
        // Tim ve cac user thuoc role 
        try
        {
            return Ok(await _baseUser.GetListByAsync(i => i.Role.Id == id));
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("updateUser")]
    public async Task<ActionResult<IEnumerable<User>>> updateUser([FromBody] UserDTO user)
    {
        // Tim ve cac user thuoc role 
        try
        {
            var userDb = await _baseUser.GetByIdAsync(user.Id);

            if(userDb.Id>0)
            {
                userDb.Username = user.Username;
                userDb.Fullname = user.Fullname;
                userDb.IdRole = user.IdRole;
                userDb.IdCard = user.IdCard;
                userDb.Phone = user.Phone;
                userDb.Dob = user.Dob;

                await _baseUser.UpdateAsync(userDb);

                return Ok(await _baseUser.Entities.Include(i => i.Role).OrderByDescending(i => i.Id).ToListAsync());
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findAllUser")]
    public async Task<ActionResult<IEnumerable<User>>> findAllUser()
    {
        try
        {
            return Ok(await _baseUser.Entities.Include(i => i.Role).ToListAsync());
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return BadRequest();
        }
    }
}

