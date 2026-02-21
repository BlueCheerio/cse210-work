public class Menu
{
    public void StartMenu()
    {
        Console.WriteLine("-----Welcome to the Scripture Memorizer Program!-----\n");
    }
    public int DisplayMenu()
    {
        Console.WriteLine("Please choose one of the following options:");
        Console.WriteLine("1. Generate a random verse to memorize");
        Console.WriteLine("2. Input a reference and verse to memorize");
        Console.WriteLine("Input 1 or 2: ");
        int userinput = int.Parse(Console.ReadLine());
        return userinput;
    }
    public void DiplayKeyChoices()
    {
        Console.WriteLine("\nPress [Enter] to make more words disappear (or end program if no words left). Type 'quit' to end the prgram: ");
    }
}