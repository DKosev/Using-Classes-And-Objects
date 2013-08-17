using System;

/* Write a program that generates and prints to the 
 * console 10 random values in the range [100, 200]. */

class GenerateRandomNumber
{
    static void Main()
    {
        // Create the array
        int[] array = new int[10];
        
        // Fill and print the array
        RandomNumberGenerator(array);
        PrintArray(array);
    }

    // Generate random numbers and fill them in array
    private static void RandomNumberGenerator(int[] array)
    {
        int min = 100;
        int max = 201;
        Random randNumber = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = randNumber.Next(min, max);
        }
    }

    // Print the filled array
    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}
