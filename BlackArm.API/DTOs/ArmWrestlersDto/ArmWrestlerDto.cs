namespace BlackArm.API.DTOs;

public class ArmWrestlerDto
{
    public Guid ArmWrestlerId { get; set; }
    
    public string FullName { get; set; }
    
    public string NickName { get; set; }
    
    public string Country { get; set; }
    
    
    public int Weight { get; set; }
    
    public int Height { get; set; }
    
    public int Bicep { get; set; }
    
    public int Forearm { get; set; }
    
    public int Wins { get; set; }
    
    public int Losses { get; set; }
    
    public int WinRate { get; set; }
    
    public int Age { get; set; }
    
    
    public DateTimeOffset BirthDate { get; set; }
}