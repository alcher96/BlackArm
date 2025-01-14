using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class Fight
{
    [Key]
    public Guid FightId { get; set; }

    [Required]
    [ForeignKey("Competition")]
    public Guid CompetitionId { get; set; }
    
    [Required]
    [ForeignKey("Wrestler1")]
    public Guid Wrestler1Id { get; set; }

    [Required]
    [ForeignKey("Wrestler2")]
    public Guid Wrestler2Id { get; set; }
    
    [Required]
    [ForeignKey("Winner")]
    public Guid WinnerId { get; set; }

    // Navigation properties:
    public virtual Competition Competition { get; set; }
    public virtual ArmWrestler Wrestler1 { get; set; }
    public virtual ArmWrestler Wrestler2 { get; set; }
    public ArmWrestler Winner { get; set; }

    // Navigation property: One Fight to Many Rounds
    public virtual ICollection<Round> Rounds { get; set; }
}