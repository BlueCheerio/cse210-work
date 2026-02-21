using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //This is our scripture bank, it allows us to store some default scriptures to memorize
    private static Dictionary<int, List<string>> AllScriptures = new Dictionary<int, List<string>>()
    {
        { 0, new List<string> {"John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."}},
        { 1, new List<string> {"Ether 12:4", "Wherefore, whoso believeth in God might with surety hope for a better world, yea, even a place at the right hand of God, which hope cometh of faith, maketh an anchor to the souls of men, which would make them sure and steadfast, always abounding in good works, being led to glorify God"}},
        { 2, new List<string> {"D&C 10:67-68", "Behold, this is my doctrine whosoever repenteth and cometh unto me, the same is my church", "Whosoever declareth more or less than this, the same is not of me, but is against me; therefore he is not of my church"}}
    };

    //Create an instance of our menu
    private static Menu menu = new Menu();

    static void Main(string[] args)
    {
        //Display the starting options to the user (this could be added onto to make it a whole loop program)
        menu.StartMenu();
        int menuchoice = menu.DisplayMenu();

        //We are assuming that each scripture has at least one verse, we must initialize this outside the if/else statement to use it later
        int numberofverses = 1;

        //Create a null instance of the scripture before we even set it, that way we can use it outside the brackets
        Scripture TheScripture = null;

        //If else block for using the different Scripture constructors
        if (menuchoice == 1)
        {
            //Select one of the 3 default scriptures
            TheScripture = new Scripture(AllScriptures);
            numberofverses = TheScripture.GetNumberVerses();
        }
        else if (menuchoice == 2)
        {
            //We need to collect the scripture reference, number of verses, and each verse from the user in order to create their custom scripture
            //I would make this a lot more case sensitive if I wanted it to be cool and i had more time
            Console.Write("Please type the scripture reference: ");
            string scripturereference = Console.ReadLine();
            Console.Write("Please input the number of verses in the scripture (A number): ");
            numberofverses = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the first verse (or only verse if there is one): ");
            string verse = Console.ReadLine();

            //Use the second Scripture constructor
            TheScripture = new Scripture(scripturereference, verse, AllScriptures);

            //If the user wants to memorize multiple verses they need to input them seperately (makes it easy to organize)
            if (numberofverses > 1)
            {
                for (int i = 1; i < numberofverses; i++)
                {
                    Console.WriteLine("Please input the next verse: ");
                    AllScriptures[AllScriptures.Count - 1].Add(Console.ReadLine());
                }
            }
        }

        //We must initialize the words in each verse of the scripture. Because the reference is stored at 0 we must start at 1
        for (int i = 1; i <= numberofverses; i++)
        {
            TheScripture.MakeScriptureWords(AllScriptures, i);
        }

        //Now the user starts the "memorization"
        bool memorizing = true;

        //This is where we can check if the user ever types "quit"
        string currentreading = "";

        //Print out the screen (or initialize the user experience)
        Console.Clear();
        TheScripture.DisplayScripture(AllScriptures);
        menu.DiplayKeyChoices();

        while (memorizing)
        {
            //Read the user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (currentreading.ToLower() == "quit")
                {
                    break;
                }
                else if (currentreading == "")
                {
                    //Check to see if there are any words still not hidden, We do this at the start because we want
                    //the user to still memorize the verse even when nothing is showing, then when the press enter
                    //for the last time the program will finally end
                    if (!TheScripture.StillWordsLeft())
                    {
                        break;
                    }

                    //Reset the screen
                    TheScripture.SetWordsInvisible();
                    Console.Clear();
                    TheScripture.DisplayScripture(AllScriptures);
                    menu.DiplayKeyChoices();
                }

                //This will clear what we have registered as the user inputs so far
                currentreading = "";
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                // This will read if the user needs to delete a character. I got this chunk of code from AI because I think it's super necessary 
                if (currentreading.Length > 0)
                {
                    currentreading = currentreading.Remove(currentreading.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                // Add the character to current reading and then show it to the user, since this isn't a ReadLine and it isn't done automatically
                currentreading += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
        }
        Console.Clear();
        Console.WriteLine("-----Thank you for playing Scripture Memorizer!-----");
    }
}