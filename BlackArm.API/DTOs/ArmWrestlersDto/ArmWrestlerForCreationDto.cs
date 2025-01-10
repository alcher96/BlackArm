namespace BlackArm.API.DTOs;

public class ArmWrestlerForCreationDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
   
    public string NickName { get; set; }

   
    public string Country { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    
    public int Weight { get; set; }
    
    public int Height { get; set; }
    
   
    public int Bicep { get; set; }
    
    public int Forearm { get; set; }
    
    public int Wins { get; set; }
    
    public int Losses { get; set; }
}