using EtiqaContact.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EtiqaContact.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? _secretKey;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
        // TODO: Configure JWT settings
        _secretKey = _configuration["JwtSettings:SecretKey"];
        if (string.IsNullOrEmpty(_secretKey))
        {
            throw new ArgumentNullException(nameof(_secretKey), "Secret Key is not configured properly.");
        }
    }

    // TODO: Configure user security settings
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        if (loginModel.Username == _configuration["UserAdmin:UserName"] && loginModel.Password == _configuration["UserAdmin:Password"])
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);  
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginModel.Username),
                    new Claim(ClaimTypes.Role, _configuration["UserAdmin:Role"])  
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                Issuer = "https://localhost:5001",  
                Audience = "https://localhost:5001", 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        if (loginModel.Username == _configuration["User:UserName"] && loginModel.Password == _configuration["User:Password"])
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginModel.Username),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                Issuer = "https://localhost:5001",
                Audience = "https://localhost:5001",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        return Unauthorized();
    }
}