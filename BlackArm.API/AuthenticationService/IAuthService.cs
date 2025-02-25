using BlackArm.API.DTOs.AuthrizationDto;

namespace BlackArm.Application.AuthenticationService;


public interface IAuthService
{
    Task<string> Register(RegisterModelDto model);
    Task<string> RegisterAdmin(RegisterModelDto model);
    Task<string> Login(LoginModelDto model);
}