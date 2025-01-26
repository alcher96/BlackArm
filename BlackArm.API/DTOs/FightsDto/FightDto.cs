using BlackArm.Domain.Models;

namespace BlackArm.API.DTOs.FightsDto;

public class FightDto
{
    public Guid FightId { get; set; }

    

    public string Wrestler1 { get; set; }


    public string Wrestler2 { get; set; }
    

    public string Winner { get; set; }
    
    public string BestOf {get; set;}
    
    public string Hand { get; set; }


}