namespace CollegeFestMVC.Extensions;

public static class ParticipantExtensions
{
    public static string GetRegistrationStatus(
        this Participant participant)
    {
        if (participant.ParticipantId > 0 &&
            !string.IsNullOrWhiteSpace(participant.EventName))
        {
            return "Confirmed";
        }

        return "Pending";
    }

    public static string GetFeeCategory(
        this Participant participant)
    {
        decimal fee = participant.RegistrationFee ?? 0;

        if (fee == 0)
        {
            return "Free Event";
        }

        if (fee <= 500)
        {
            return "Standard Event";
        }

        return "Premium Event";
    }
}