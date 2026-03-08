using System;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            //Menu start
            Console.WriteLine("Please choose an activty to do:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listening");
            Console.WriteLine("Please type 1, 2 or 3: ");
            string activitychoice = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please input a duration (in seconds, 60 seconds or more is recommended):");
            string durationchoice = Console.ReadLine();
            int duration = int.Parse(durationchoice);

            //We don't need to name the instances since they run themselves (aka: there is no "Run" function in them)
            if (activitychoice == "1")
            {
                new Breathing("Breathing", duration);
            }
            else if (activitychoice == "2")
            {
                new Reflection("Refelction", duration);
            }
            else if (activitychoice == "3")
            {
                new Listening("Listening", duration);
            }
            else
            {
                Console.WriteLine("You didn't type 1, 2, or 3, please try again");
            }

            //A repeat loop for the program
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Would you like to do another activity? (y/n):");
            if (Console.ReadLine() == "y")
            {
                Thread.Sleep(200);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                break;
            }
        }
        Console.WriteLine("-----Come Again Soon-----");
    }
}