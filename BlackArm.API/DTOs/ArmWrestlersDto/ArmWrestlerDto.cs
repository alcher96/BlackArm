namespace BlackArm.API.DTOs;

public class ArmWrestlerDto
{
    public Guid ArmWrestlerId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string NickName { get; set; }
    
    public string Country { get; set; }
    
    
    public int Weight { get; set; }
    
    public int Height { get; set; }
    
    public int Bicep { get; set; }
    
    public int Forearm { get; set; }
    
    public int Wins { get; set; }
    
    public int Losses { get; set; }
    
    

    public int SidePressure { get; set; }
    

    public int Wrist  { get; set; }
    

    public int Angle { get; set; }
    

    public int Stamina { get; set; }
    
  
    public int Pronaton { get; set; }
    
    public string? PhotoPath { get; set; } // Путь к фото на сервере
    
    
    public DateTimeOffset BirthDate { get; set; }
}