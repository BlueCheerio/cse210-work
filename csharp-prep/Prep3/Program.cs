using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        bool playing = true;
        while (playing)
        {
            playing = false;
            bool guessing = true;
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            Console.WriteLine("Welcome to the number guessing game! You get to guess a number between 1-100");
            while (guessing)
            {
                Console.WriteLine("What is your guess? ");
                string answer = Console.ReadLine();
                int guess = int.Parse(answer);
                if (guess > number)
                {
                    Console.WriteLine("lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("higher");
                }
                else if (guess == number)
                {
                    Console.WriteLine("Congratulations you guessed it!");
                    guessing = false;
                }
                else
                {
                    Console.WriteLine("We're not sure what number that is");
                }
            }
            Console.WriteLine("\nWould you like to play again? (Y/N)");
            string again = Console.ReadLine();
            if (again == "Y" || again == "y")
            {
                playing = true;
            }
            else
            {
                Console.WriteLine("\nThanks for playing!");
            }
        }
    }
}