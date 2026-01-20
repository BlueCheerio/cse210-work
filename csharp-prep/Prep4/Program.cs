using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
        bool enter = true;
        List<int> numbers = new List<int>();
        while (enter)
        {
            Console.WriteLine("Enter Number: ");
            string read = Console.ReadLine();
            if (read != "0")
            {
                int numberinput = int.Parse(read);
                numbers.Add(numberinput);
            }
            else
            {
                enter = false;
            }
        }
        int sum = 0;
        float average = 0;
        int largest = 0;
        int numofnumbers = numbers.Count;
        foreach (int number in numbers)
        {
            sum = sum + number;
            if (number > largest)
            {
                largest = number;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        average = sum / (float)numofnumbers;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}