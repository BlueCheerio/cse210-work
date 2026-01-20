using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string name = PromptUserName();
        int favnumber = PromptUserNumber();
        int birthyear;
        PromptUserBirthYear(out birthyear);
        int square = SquareNumber(favnumber);
        DisplayResult(name, birthyear, square);
    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter Your favorite number: ");
        int favnumber = int.Parse(Console.ReadLine());
        return favnumber;
    }
    static void PromptUserBirthYear(out int birthyear)
    {
        Console.WriteLine("Please enter the year you were born: ");
        birthyear = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        number = number * number;
        return number;
    }
    static void DisplayResult(string name, int birthyear, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
        Console.WriteLine($"{name}, you will turn {2026-birthyear} this year");
    }

}