using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

/* You are given a sequence of positive integer values written 
 * into a string, separated by spaces. Write a function that 
 * reads these values from given string and calculates their sum. 
 * Example: string = "43 68 9 23 318"  result = 461 */

class SumIntsInString
{
    static void Main()
    {
        // Input numbers
        Console.Write("Enter the numbers separated by a single space:\n=> ");
        string inputNumbers = Console.ReadLine();

        // Split the numbers in a list
        List<string> numbers = inputNumbers.Split(' ').ToList();

        // Print the sum result
        BigInteger result = SumIntsFromList(numbers);
        Console.WriteLine("The sum of all numbers is: {0}", result);
    }

    // Sum the ints from the list
    private static BigInteger SumIntsFromList(List<string> numbers)
    {
        BigInteger sumNumbers = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sumNumbers += BigInteger.Parse(numbers[i]);
        }

        return sumNumbers;
    }
}