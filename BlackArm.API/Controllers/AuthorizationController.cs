using BlackArm.API.DTOs.AuthrizationDto;
using BlackArm.Application.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace BlackArm.API.Controllers;

public class AuthorizationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthorizationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelDto model)
    {
        var result = await _authService.Register(model);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelDto model)
    {
        var token = await _authService.Login(model);
        return Ok(new { Token = token , Successful = true });
    }

    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin(RegisterModelDto model)
    {
        var result = await _authService.RegisterAdmin(model);
        return Ok(result);
    }
}