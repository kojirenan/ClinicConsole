namespace Clinic.Utils;

internal static class DateRandom
{
    private static Random _random = new();
    private static DateTime _today = DateTime.Today;
    
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
    
    private static DateTime GenerateRandomDayOfWeek(int maxDayAhead)
    {
        DateTime randomDate;
        bool isWeekend;
        do
        {
            int dayToAdd = _random.Next(1, maxDayAhead + 1);
            randomDate = _today.AddDays(dayToAdd);
            
            isWeekend = randomDate.DayOfWeek == DayOfWeek.Saturday && randomDate.DayOfWeek == DayOfWeek.Sunday;
        } while (isWeekend);

        DateTime generateRandomDate = AddRandomTime(randomDate);
        return generateRandomDate;
    }
    
    private static DateTime AddRandomTime(DateTime dateTime)
    {
        int randomHour = _random.Next(8, 17);
        int[] validMinutes = {0, 15, 30, 45};
        int randomMinute = validMinutes[_random.Next(validMinutes.Length)];

        return dateTime.AddHours(randomHour).AddMinutes(randomMinute);
    }
}