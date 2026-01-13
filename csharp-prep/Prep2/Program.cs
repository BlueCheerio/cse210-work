using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "A";
        bool pass = true;
        Console.WriteLine("Input your grade percentage: ");
        string usergrade = Console.ReadLine();
        int grade = int.Parse(usergrade);

        if (grade >= 93)
        {
            letter = "A";
        }
        else if (grade >= 90)
        {
            letter = "A-";
        }
        else if (grade >= 87)
        {
            letter = "B+";
        }
        else if (grade >= 83)
        {
            letter = "B";
        }
        else if (grade >= 80)
        {
            letter = "C+";
        }
        else if (grade >= 77)
        {
            letter = "C+";
        }
        else if (grade >= 73)
        {
            letter = "C";
        }
        else if (grade >= 70)
        {
            letter = "C-";
        }
        else if (grade >= 67)
        {
            letter = "D+";
            pass = false;
        }
        else if (grade >= 63)
        {
            letter = "D";
            pass = false;
        }
        else if (grade >= 60)
        {
            letter = "D-";
            pass = false;
        }
        else
        {
            letter = "F";
            pass = false;
        }
        Console.WriteLine($"Your grade letter is: {letter}");
        if (pass)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You did not pass the class, do your homework next time!");
        }

    }
}