using System.ComponentModel.DataAnnotations;

namespace CollegeFestMVC.Models;

public class Event
{
    public int EventId { get; set; }

    [Required]
    public string EventName { get; set; } = string.Empty;

    [Range(1, 1000)]
    public int MaximumParticipants { get; set; }

    [Range(0, 100000)]
    public decimal RegistrationFee { get; set; }
}