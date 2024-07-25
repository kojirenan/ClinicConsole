namespace Clinic.Utils;

internal static class TimeRandom
{
    private static Random _random = new();

    internal static DateTime AddRandomTime(DateTime dateTime)
    {
        int randomHour = _random.Next(8, 17);
        int[] validMinutes = {0, 15, 30, 45};
        int randomMinute = validMinutes[_random.Next(validMinutes.Length)];

        return dateTime.AddHours(randomHour).AddMinutes(randomMinute);
    }
}