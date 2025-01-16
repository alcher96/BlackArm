using System.ComponentModel.DataAnnotations;

namespace BlackArm.Domain.Models;

public class WrestlingStyle
{
    [Key]
    public Guid StyleId { get; set; }

    [Required]
    [StringLength(255)] // Adjust the length as needed
    public string StyleName { get; set; }

    // Navigation Properties
    public ICollection<Fight> FightsUsingStyle { get; set; }
    public ICollection<Round> RoundsUsingStyle { get; set; }
}