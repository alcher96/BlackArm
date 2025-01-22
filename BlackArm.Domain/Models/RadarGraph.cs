using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class RadarGraph
{
    [Key]
    public Guid GraphId { get; set; }
    
    [Required]
   // [ForeignKey("Wrestler")] // Foreign Key and also used for the one-to-one
    public Guid WrestlerId { get; set; }
    
    [Range(1, 10)]
    public int PronatorStrength { get; set; }
    
    [Range(1, 10)]
    public int WristStrength { get; set; }
    
    [Range(1, 10)]
    public int SidePressure { get; set; }
    
    [Range(1, 10)]
    public int Stamina { get; set; }
    
    [Range(1, 10)]
    public int AngleStrenght { get; set; }
    
    // Navigation property for the one-to-one relationship
    public virtual ArmWrestler Wrestler { get; set; }
}