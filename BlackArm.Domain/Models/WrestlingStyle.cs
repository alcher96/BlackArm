using System.ComponentModel.DataAnnotations;

namespace BlackArm.Domain.Models;

public class WrestlingStyle
{
    [Key]
    public Guid StyleId { get; set; }

    [Required]
    [StringLength(255)] // Adjust the length as needed
    public string StyleName { get; set; }

    // Navigation property (optional if you need to access Rounds from Style)
    public virtual ICollection<Round> RoundsUsedIn { get; set; }
}