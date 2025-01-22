namespace BlackArm.API.DTOs.RoundsDto;

public class RoundForCreationDto
{
    public int RoundNumber { get; set; }
    public Guid WinnerId { get; set; }
    
    public Guid StyleUsedId { get; set; }
}