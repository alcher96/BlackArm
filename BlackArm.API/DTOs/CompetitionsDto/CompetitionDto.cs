namespace BlackArm.API.DTOs.CompetitionsDto;

public class CompetitionDto
{
    public Guid CompetitionId { get; set; }
    
    public string CompetitionName { get; set; }
    
    public DateTime CompetitionDate { get; set; }
}