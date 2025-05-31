using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp6.Models.DTOs;
using WebApp6.Utils;

namespace WebApp6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == "admin" && user.Password == "1234567890")
            {
                var secretKey = 
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("74dd743d9755d18348997845d7adb544")); 
				var signinCredentials = 
                    new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = 
                    new JwtSecurityToken(
                        issuer: ConfigurationManagerAPI.AppSetting["JWT:ValidIssuer"], 
                        audience: ConfigurationManagerAPI.AppSetting["JWT:ValidAudience"], 
                        claims: new List<Claim>(), 
                        expires: DateTime.Now.AddMinutes(1000), 
                        signingCredentials: signinCredentials);
                var tokenString = 
                    new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}
