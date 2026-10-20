using CollegeFestMVC.Extensions;

namespace CollegeFestMVC.Controllers;

public class FestController : Controller
{
    private static readonly List<Participant> Participants = new();

    private static readonly List<Event> Events = new()
    {
        new Event
        {
            EventId = 1,
            EventName = "Code Sprint",
            MaximumParticipants = 100,
            RegistrationFee = 0
        },

        new Event
        {
            EventId = 2,
            EventName = "AI Innovation Challenge",
            MaximumParticipants = 50,
            RegistrationFee = 300
        },

        new Event
        {
            EventId = 3,
            EventName = "Hackathon",
            MaximumParticipants = 60,
            RegistrationFee = 750
        },

        new Event
        {
            EventId = 4,
            EventName = "Cyber Security Challenge",
            MaximumParticipants = 40,
            RegistrationFee = 500
        }
    };

    // GET: /Fest
    public IActionResult Index()
    {
        return View(Participants);
    }

    // GET: /Fest/Register
    [HttpGet]
    public IActionResult Register()
    {
        ViewBag.Events = Events;

        return View();
    }

    // POST: /Fest/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Participant participant)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Events = Events;

            return View(participant);
        }

        var selectedEvent = Events.FirstOrDefault(
            e => e.EventName == participant.EventName);

        if (selectedEvent == null)
        {
            ModelState.AddModelError(
                "EventName",
                "Please select a valid event.");

            ViewBag.Events = Events;

            return View(participant);
        }

        bool alreadyRegistered = Participants.Any(
            p =>
                p.Email.Equals(
                    participant.Email,
                    StringComparison.OrdinalIgnoreCase)
                &&
                p.EventName == participant.EventName
        );

        if (alreadyRegistered)
        {
            ModelState.AddModelError(
                "Email",
                "This participant is already registered for this event.");

            ViewBag.Events = Events;

            return View(participant);
        }

        participant.ParticipantId =
            Participants.Count == 0
                ? 1
                : Participants.Max(p => p.ParticipantId) + 1;

        participant.RegistrationFee =
            selectedEvent.RegistrationFee;

        participant.RegisteredAt =
            DateTime.Now;

        Participants.Add(participant);

        TempData["SuccessMessage"] =
            $"Registration successful for {participant.ParticipantName}!";

        return RedirectToAction(nameof(Index));
    }

    // GET: /Fest/Details/1
    public IActionResult Details(int id)
    {
        var participant = Participants.FirstOrDefault(
            p => p.ParticipantId == id);

        if (participant == null)
        {
            return NotFound();
        }

        return View(participant);
    }

    // GET: /Fest/Welcome
    public IActionResult Welcome()
    {
        return View();
    }
}