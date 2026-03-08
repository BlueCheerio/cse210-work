using System;
using System.Formats.Tar;
using System.Reflection;
using System.Reflection.Metadata;


public class Program
{
    public static Journal journalMain = new Journal();

    public static void Main()
    {
        Console.WriteLine("Welcome to the Journal Program! Here to help you keep up your consistent journaling habits!");

        while (true)
        {
            int menuinput = DisplayMenu();
            if (menuinput == 1)
            {
                journalMain.NewPrompt(); //This creates and saves a new prompt class and prints itself
                journalMain.NewEntry(); //Creates a new entry that will read and save what the user types
            }
            else if (menuinput == 2)
            {
                journalMain.PrintSelf();
            }
            else if (menuinput == 3)
            {
                journalMain.SaveJournal(); //Journal saves itself to a file
            }
            else if (menuinput == 4)
            {
                journalMain.LoadJournal(); //Journal will clear it's lists and upload lists from a saved file
            }
            else if (menuinput == 5)
            {
                Console.WriteLine("Make sure you save your current journal! Are you sure you want to continue? (y/n)\n");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    Console.WriteLine("\nThank you for writing in your journal today! See you soon!");
                    break;
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        // This function makes the user choose from the menu options and handles cases that aren't 1-4 or a string.
        int DisplayMenu()
        {
            bool menuchoosing = true;
            int menuchoice = 0;

            while (menuchoosing)
            {
                Console.WriteLine("\n-----Journal Menu-----\n1. Write a new entry\n2. Display the journal\n3. Save current journal\n4. Load a journal\n5. Quit Program\n\n(Please type a number 1-5): ");
                string userinput = Console.ReadLine();

                try
                {
                    menuchoice = int.Parse(userinput);
                    if (menuchoice > 0 && menuchoice < 6)
                    {
                        menuchoosing = false;
                    }
                    else
                    {
                        Console.WriteLine("Please input a number from 1-5!\n");
                    }
                }
                catch (FormatException)   // I looked up the exception for this part
                {
                    Console.WriteLine($"Error: '{userinput}' is not a number, please try again\n");
                }
            }

            return menuchoice;
        }
    }
}