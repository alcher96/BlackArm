//using BlackArm.API.Attributes;

using BlackArm.API.Attributes;

namespace BlackArm.API.DTOs.FightsDto;

public class FightForCreatingDto
{

   [NotEqual("Wrestler2Id", ErrorMessage = "Wrestler1Id and Wrestler2Id cannot be the same.")]
    public Guid Wrestler1Id { get; set; }

    [NotEqual("Wrestler1Id", ErrorMessage = "Wrestler1Id and Wrestler2Id cannot be the same.")]
    public Guid Wrestler2Id { get; set; }
    
    public Guid WinnerId { get; set; }
    
    public string BestOf {get; set;}
    
    public string Hand { get; set; }
    


}