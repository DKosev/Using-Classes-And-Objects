using System;

/* Write a program that reads a year from the console 
 * and checks whether it is a leap. Use DateTime. */

class CheckYearIfLeap
{
    static void Main()
    {
        // Input year data
        Console.WriteLine("You can check all leap years in the interval of two years:");
        Console.WriteLine("Enter the first year: ex. => 1500");
        int startYear = int.Parse(Console.ReadLine());
        if (startYear <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\aError! The first year can't be negative or equal to zero.\n");
            Console.ResetColor();
            Main();
        }

        Console.WriteLine("Now enter the second year: ex. => 2013");
        int stopYear = int.Parse(Console.ReadLine());
        if (stopYear <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\aError! Please try again.");
            Console.WriteLine("The second year can't be negative or equal to zero.\n");
            Console.ResetColor();
            Main();
        }
        else if (stopYear <= startYear)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\aError! Please try again.");
            Console.WriteLine("The first year have to be greater than the second year.\n");
            Console.ResetColor();
            Main();
        }

        // Output leap years
        IsLeapYear(startYear, stopYear);
    }

    // Find all leap years in interval
    private static void IsLeapYear(int startYear, int stopYear)
    {
        for (int currentYear = startYear; currentYear <= stopYear; currentYear++)
        {
            if (DateTime.IsLeapYear(currentYear))
            {
                Console.WriteLine("{0} is leap", currentYear);
            }
        }
    }
}