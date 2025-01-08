using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class Round
{
    [Key]
    public Guid RoundId { get; set; }
    
    [Required]
    [ForeignKey("Fight")]
    public Guid FightId { get; set; }
    
    [Required]
    [Range(1, 6)] // Enforce the 1-6 range
    public int RoundNumber { get; set; }

    [Required]
    [ForeignKey("Winner")] // Foreign key to Wrestler (winner)
    public Guid WinnerId { get; set; }

    [Required]
    [ForeignKey("StyleUsed")] // Foreign key to WrestlingStyle
    public Guid StyleUsedId { get; set; }

    // Navigation properties:
    public virtual Fight Fight { get; set; }
    public virtual ArmWrestler Winner { get; set; }
    public virtual WrestlingStyle StyleUsed { get; set; }
}