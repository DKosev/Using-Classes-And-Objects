using System;

/* Write a method that calculates the number of workdays between 
 * today and given date, passed as parameter. Consider that workdays 
 * are all days from Monday to Friday except a fixed list of public
 * holidays specified preliminary as array. */

class CalculateWorkdays
{
    static void Main()
    {
        // Input
        Console.WriteLine("You can enter future date or past date in format YYYY/MM/DD");
        DateTime enteredDate = DateTime.Parse(Console.ReadLine());
        
        // Output
        int result = CalculateWorkingDays(enteredDate);
        if (result > 0)
        {
            Console.WriteLine("There are {0} working days between the entered date and the future date.", result);
        }
        else if (result < 0)
        {
            Console.WriteLine("There were {0} working days between the entered date and the past date.", result);
        }
        else
        {
            Console.WriteLine("There aren't any working days between current date and the entered date.");
        }
    }

    private static int CalculateWorkingDays(DateTime enteredDate)
    {
        // Create array with holiday dates
        DateTime[] holidayDates =
        {
            new DateTime(2013, 01, 01),
            new DateTime(2013, 03, 03),
            new DateTime(2013, 05, 01),
            new DateTime(2013, 05, 02),
            new DateTime(2013, 05, 06),
            new DateTime(2013, 05, 24),
            new DateTime(2013, 09, 06),
            new DateTime(2013, 09, 22),
            new DateTime(2013, 11, 01),
            new DateTime(2013, 12, 24),
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2013, 12, 31)
        };

        // Assign the current day
        DateTime currentDay = DateTime.Today;

        // Calculate the days number in the interval of the entered date and the current date
        int sumAllDays = (enteredDate - currentDay).Days;

        // Make all days as working days and substract the holidays plus Saturdays and Sundays
        int workingDays = sumAllDays;
        while (currentDay <= enteredDate)
        {
            if (currentDay.DayOfWeek == DayOfWeek.Saturday || currentDay.DayOfWeek == DayOfWeek.Sunday)
            {
                workingDays--;
            }
            else
            {
                for (int i = 0; i < holidayDates.Length; i++)
                {
                    if (currentDay == holidayDates[i])
                    {
                        workingDays--;
                    }
                }
            }

            currentDay = currentDay.AddDays(1);
        }

        return workingDays;
    }
}
