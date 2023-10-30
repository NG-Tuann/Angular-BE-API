using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ptj_server.Helpers;
using ptj_server.Interfaces;
using ptj_server.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ptj_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly IBaseRepository<Customer> _baseCustomerRepository;

        private readonly IConfiguration _configuration;

        public CustomerController(IBaseRepository<Customer> baseCustomerRepository, IConfiguration configuration)
        {
            _baseCustomerRepository = baseCustomerRepository;
            _configuration = configuration;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginModel model)
        {
            try
            {
                var validCustomer = await _baseCustomerRepository.GetByAsync(i => i.Username.Equals(model.Username));

                if (validCustomer == null)
                {
                    return Ok("invalid-user");
                }

                if (!BCrypt.Net.BCrypt.Verify(model.Password, validCustomer.Password))
                {
                    return Ok("invalid-password");
                }

                var jwtHelper = new JwtHelper(_configuration);

                var token = jwtHelper.CreateCustomerJwtToken(validCustomer.Username,validCustomer.Id.ToString(), validCustomer.Fullname);
                return Ok(token);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest("fail");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterModel register)
        {
            try
            {
                // Kiem tra username ton tai
                var existCustomer = await _baseCustomerRepository.GetByAsync(i => i.Username.Equals(register.Mail));

                if (existCustomer != null && existCustomer.Id > 0)
                    return Ok("Email exist");

                // Luu customer
                var newCus = new Customer();
                newCus.Username = register.Mail;

                // Gan mat khau otp
                Random rnd = new Random();

                var randomPassword = rnd.Next(100000, 999999);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPassword.ToString());

                newCus.Password = passwordHash;
                newCus.Fullname = register.FullName;

                await _baseCustomerRepository.AddAsync(newCus);

                // Gui otp dang nhap

                var mailHelper = new MailHelper(_configuration);
                string subject = "Mail gửi với mục đích kích hoạt tài khoản và thông tin về mật khẩu";
                string content = "Sau khi nhận mật khẩu hãy đăng nhập và thay đổi mật khẩu. Mật khẩu của bạn là: " + randomPassword;
                if (await mailHelper.Send("tuan.ng400@aptechlearning.edu.vn", register.Mail, subject, content))
                {
                    Debug.WriteLine("Send mail success");
                }
                else
                {
                    Debug.WriteLine("Send mail fail");
                }

                return Ok("Register success");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

