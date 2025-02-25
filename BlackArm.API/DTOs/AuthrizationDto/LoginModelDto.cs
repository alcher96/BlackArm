namespace BlackArm.API.DTOs.AuthrizationDto;

public class LoginModelDto
{
    bool Successful { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}