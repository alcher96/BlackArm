using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class ArmWrestler
{
    [Key]
    public Guid ArmWrestlerId { get; set; }
    
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(30)]
    public string LastName { get; set; }
    
    [StringLength(30)]
    public string NickName { get; set; }

    [Required]
    [StringLength(30)]
    public string Country { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    
    public int Weight { get; set; }
    
    public int Height { get; set; }
    
    [Range(1, 90)]
    public int Bicep { get; set; }
    
    [Range(1, 90)]
    public int Forearm { get; set; }
    
    public int Wins { get; set; }
    
    public int Losses { get; set; }
    
    
    // Navigation properties for relationships (optional, but useful for querying)
    [InverseProperty("Wrestler1")]
    public virtual ICollection<Fight> FightsAsWrestler1 { get; set; }
    
    [InverseProperty("Wrestler2")]
    public virtual ICollection<Fight> FightsAsWrestler2 { get; set; }
    [InverseProperty("Winner")]
    public virtual ICollection<Round> RoundsWon { get; set; }
    
    
    // One-to-One relationship with RadarGraph
    public virtual RadarGraph RadarGraph { get; set; }
}