using System.ComponentModel.DataAnnotations;

namespace CollegeFestMVC.Models;

public class Participant
{
    public int ParticipantId { get; set; }

    [Required(ErrorMessage = "Participant name is required.")]
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "Participant Name")]
    public string ParticipantName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select your year.")]
    public string Year { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select an event.")]
    [Display(Name = "Event Name")]
    public string EventName { get; set; } = string.Empty;

    [Display(Name = "Team Event")]
    public bool IsTeamEvent { get; set; }

    public decimal? RegistrationFee { get; set; }

    public DateTime RegisteredAt { get; set; }
}