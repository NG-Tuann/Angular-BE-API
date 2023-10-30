using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ptj_server.Helpers
{
	public class JwtHelper
	{
        public IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateCustomerJwtToken(string username, string userId, string fullname)
        {
            var secretKey = _configuration.GetSection("AppSettings:Token").Value!;
            // Tạo các thông tin về người dùng (claims)
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, fullname),
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Khóa bí mật sử dụng để ký (sign) token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: "PTJ",
                audience: "Customer",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // Thời gian hết hạn của token (7 ngày)
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Chuyển đổi token thành chuỗi
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public string CreateUserJwtToken(string username, string userId, string fullname, string role)
        {
            var secretKey = _configuration.GetSection("AppSettings:Token").Value!;
            // Tạo các thông tin về người dùng (claims)
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, fullname),
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Khóa bí mật sử dụng để ký (sign) token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: "PTJ",
                audience: "User",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // Thời gian hết hạn của token (7 ngày)
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Chuyển đổi token thành chuỗi
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}

