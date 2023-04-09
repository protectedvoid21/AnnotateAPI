using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller {
    private readonly UserManager<AppUser> userManager;
    private readonly string jwtKey;

    public UserController(UserManager<AppUser> userManager,  
        IConfiguration configuration) {
        this.userManager = userManager;
        jwtKey = configuration["jwt:Key"];
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto) {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName.Equals(loginDto.UserName));
        if(user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password)) {
            return Unauthorized();
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Role, "user")
            }),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Ok(new {
            token = tokenHandler.WriteToken(token),
            expiration = tokenDescriptor.Expires
        });
    }
}