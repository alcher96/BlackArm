using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackArm.Domain.Models;

public class Competition
{
    [Key]
    public Guid CompetitionId { get; set; }
    
    [Required]
    [StringLength(255)] // Adjust the length as needed
    public string CompetitionName { get; set; }

    [Required]
    [Column(TypeName = "date")] // Specify the correct type for Date
    public DateTime CompetitionDate { get; set; }

    // Navigation property: One Competition to Many Fights
    public virtual ICollection<Fight> Fights { get; set; }
}