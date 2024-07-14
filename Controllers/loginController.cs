using CRM_Web_Api.DAL;
using CRM_Web_Api.DTO;
using CRM_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CRM_Web_Api.Services;

namespace CRM_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly login_repo _login;
        private readonly IConfiguration _configuration;


        public loginController(login_repo login, IConfiguration configuration)
        {
            _login = login;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult signin([FromBody] logindto lg)
        {
            var ud = _login.login(lg.Converttomodel());
            if (ud.Count == 0)
            {
                return NotFound("Wrong Id and Password");
            }
            int id = ud.First().user_id;
            int role=ud.First().role_id;
           //string name = Convert.ToString(ud.First().username);


            var token = GenerateJwtToken(id, role, _configuration);
         
            
            return Ok(new { token });
        }
        public static JwtSecurityToken DecodeJwtToken(string jwtToken, IConfiguration jwtSettings)
        {
            var secretKey = jwtSettings["JWT:Secret"];
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            try
            {
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out securityToken);
                return securityToken as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                // Token validation failed
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
        private static string GenerateJwtToken(int userId,int userole, IConfiguration jwtSettings)
        {
            //const int keySizeInBits = 256; // For HMAC with SHA-256
            //const int keySizeInBytes = keySizeInBits / 8; // Convert bits to bytes

            //byte[] key = new byte[keySizeInBytes];
            //using (var rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(key);
            //}
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["JWT:Secret"]));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

       

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, userole.ToString())

        // Add more claims as needed
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["JWT:ValidIssuer"],
                audience: jwtSettings["JWT:ValidAudience"],
              claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
