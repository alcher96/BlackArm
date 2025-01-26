namespace BlackArm.API.DTOs.RoundsDto;

public class RoundDto
{
    public Guid RoundId { get; set; }
    public int RoundNumber { get; set; }
    public string WinnerName { get; set; }
    
    public string StyleUsed { get; set; }
}