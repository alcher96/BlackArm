namespace BlackArm.API.DTOs.FightsDto;

public class FightForCreatingDto
{
    

    public Guid Wrestler1Id { get; set; }


    public Guid Wrestler2Id { get; set; }
    
    public Guid WinnerId { get; set; }
    
    public Guid StyleUsedId { get; set; }
}