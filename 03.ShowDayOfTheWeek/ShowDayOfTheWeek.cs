using System;
using System.Globalization;

/* Write a program that prints to the console 
 * which day of the week is today. Use System.DateTime. */

class ShowDayOfTheWeek
{
    static void Main()
    {
        // Show the date and the day name
        CurrentDate();
    }

    // Get the current date and day name in US format
    private static void CurrentDate()
    {
        DateTime currDate = DateTime.Now;
        CultureInfo culture = new CultureInfo("en-US");
        Console.WriteLine("The date today is {0} and it is {1}", currDate.ToString("d", culture), currDate.DayOfWeek);
    }
}