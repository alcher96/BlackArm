using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class Round
{
    [Key]
    public Guid RoundId { get; set; }
    
    [Required]
  //  [ForeignKey("Fight")]
    public Guid FightId { get; set; }
    
    [Required]
    [Range(1, 6)] // Enforce the 1-6 range
    public int RoundNumber { get; set; }

    [Required]
    public Guid WinnerId { get; set; }

    [Required]
    public Guid StyleUsedId { get; set; }

    // Navigation Properties
    [ForeignKey("FightId")]
    public Fight Fight { get; set; }

    [ForeignKey("WinnerId")]
    [InverseProperty("RoundsWon")]
    public ArmWrestler Winner { get; set; }

    [ForeignKey("StyleUsedId")]
    public WrestlingStyle StyleUsed { get; set; }
}