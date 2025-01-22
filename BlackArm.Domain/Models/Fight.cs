using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class Fight
{
    [Key]
    public Guid FightId { get; set; }

    [Required]
  //  [ForeignKey("Competition")]
    public Guid CompetitionId { get; set; }
    
    [Required]
  //  [ForeignKey("Wrestler1")]
    public Guid Wrestler1Id { get; set; }

    [Required]
  //  [ForeignKey("Wrestler2")]
    public Guid Wrestler2Id { get; set; }
    
    [Required]
  //  [ForeignKey("FightWinner")]
    public Guid WinnerId { get; set; }
    
    public Guid StyleUsedId { get; set; }

    // Navigation Properties
    [ForeignKey("CompetitionId")]
    public Competition Competition { get; set; }

    [ForeignKey("Wrestler1Id")]
    public ArmWrestler Wrestler1 { get; set; }

    [ForeignKey("Wrestler2Id")]
    public ArmWrestler Wrestler2 { get; set; }

    [ForeignKey("WinnerId")]
    public ArmWrestler Winner { get; set; }

    [ForeignKey("StyleUsedId")]
    public WrestlingStyle StyleUsed { get; set; }

    public ICollection<Round> Rounds { get; set; }
    
    public Fight()
    {
      Rounds = new HashSet<Round>();
    }
}