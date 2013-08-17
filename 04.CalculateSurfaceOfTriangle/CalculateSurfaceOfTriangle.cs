using System;
using System.Globalization;
using System.Threading;

/* Write methods that calculate the surface of a triangle by given:
 * Side and an altitude to it; Three sides; Two sides and an angle 
 * between them. Use System.Math. */

class CalculateSurfaceOfTriangle
{
    static void Main()
    {
        // Convert the comma in double to period
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Choose method for calculation
        Console.WriteLine("You can calculate surface of a triangle by the given methods:");
        Console.WriteLine("1. Side and an altitude to it\n2. Three sides\n3. Two sides and an angle between them");
        Console.Write("Enter the number of the desired method: => ");
        int userChoice = int.Parse(Console.ReadLine());
        switch (userChoice)
        {
            case 1:
                SideAndAltitude();
                break;
            case 2:
                ThreeSides();
                break;
            case 3:
                TwoSidesAndAngle();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\aError! Choose 1, 2 or 3 method.");
                Console.ResetColor();
                Main();
                break;
        }
    }
    
    // Calculate surface of a triangle with given side and an altitude
    private static void SideAndAltitude()
    {
        Console.Write("Enter value for the side of the triangle:\n=> ");
        double triangleSide = double.Parse(Console.ReadLine().Replace(",", "."));
        Console.Write("Now enter the altitude of the triangle:\n=> ");
        double triangleAltitude = double.Parse(Console.ReadLine().Replace(",", "."));
        double result = Math.Round(((triangleSide * triangleAltitude) / 2), 2);
        Console.WriteLine("({0} * {1}) / 2 = {2}", triangleSide, triangleAltitude, result);
    }

    // Calculate surface of a triangle with given three sides
    private static void ThreeSides()
    {
        Console.Write("Enter value for the 'a' side of the triangle:\n=> ");
        double sideA = double.Parse(Console.ReadLine().Replace(",", "."));
        Console.Write("Enter value for the 'b' side of the triangle:\n=> ");
        double sideB = double.Parse(Console.ReadLine().Replace(",", "."));
        Console.Write("Enter value for the 'c' side of the triangle:\n=> ");
        double sideC = double.Parse(Console.ReadLine().Replace(",", "."));
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        double result = Math.Round(Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC)), 2);
        Console.WriteLine("The semi perimeter is: {0}", semiPerimeter);
        Console.WriteLine("({0} * ({0} - {1}) * ({0} - {2}) * ({0} - {3})) = {4}", semiPerimeter, sideA, sideB, sideC, result);
    }

    // Calculate surface of a triangle with given two sides and an angle
    private static void TwoSidesAndAngle()
    {
        Console.Write("Enter value for the 'a' side of the triangle:\n=> ");
        double sideA = double.Parse(Console.ReadLine().Replace(",", "."));
        Console.Write("Enter value for the 'b' side of the triangle:\n=> ");
        double sideB = double.Parse(Console.ReadLine().Replace(",", "."));
        Console.Write("Enter value for the angle alpha of the triangle:\n=> ");
        double triangleAngle = double.Parse(Console.ReadLine().Replace(",", "."));
        double result = Math.Round((sideA * sideB * Math.Sin(Math.PI * triangleAngle / 180) / 2), 2);
        Console.WriteLine("{0} * {1} * sin(Pi * {2} / 180) / 2 = {3}", sideA, sideB, triangleAngle, result);
    }
}