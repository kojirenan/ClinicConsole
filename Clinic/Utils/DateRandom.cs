namespace Clinic.Utils;

internal static class DateRandom
{
    private static Random _random = new();
    private static DateTime _today = DateTime.Today;
    
    private static DateTime GenerateRandomDayOfWeek(int maxDayAhead)
    {
        DateTime randomDate;
        do
        {
            int dayToAdd = _random.Next(1, maxDayAhead + 1);
            randomDate = _today.AddDays(dayToAdd);
        } while (!IsWeekend(randomDate));

        DateTime generateRandomDate = TimeRandom.AddRandomTime(randomDate);
        return generateRandomDate;
    }

    internal static DateTime[] GenerateListDaysAppointment(int quantity, int daysAhead)
    {
        var scheduleDates = new DateTime[quantity];
        for (int i = 0; i < quantity; i++)
        {
            DateTime date = GenerateRandomDayOfWeek(daysAhead);
            scheduleDates[i] = date;
        }

        Array.Sort(scheduleDates);
        return scheduleDates;
    }

    private static bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    }
}