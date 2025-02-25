using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlackArm.API.DTOs.AuthrizationDto;
using BlackArm.Application.AuthenticationService;
using BlackArm.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BlackArm.API.AuthenticationService;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    
    
    public async Task<string> Register(RegisterModelDto model)
    {
        return await RegisterUser(model, "user");
    }
    
    
    public async Task<string> RegisterAdmin(RegisterModelDto model)
    {
        return await RegisterUser(model, "admin");
    }

    
    private async Task<string> RegisterUser(RegisterModelDto model, string role)
    {
        var user = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            return $"{role.Substring(0, 1).ToUpper() + role.Substring(1)} registered successfully!";
        }
        return string.Join(", ", result.Errors.Select(e => e.Description));
    }
    
    
    public async Task<string> Login(LoginModelDto model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        return "Invalid credentials";
    }
}