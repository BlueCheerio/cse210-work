using System.Runtime.CompilerServices;


//Note: An activty wont finish exactly on time, I beleive it is important for the user to finish their thought and then it will end.
//I also decided that activties would run straight from their constructors
//I chose to use protected variables instead of Getters and Setters because it means I write less code
public class Activity
{
    private string _name;
    protected string _description;
    protected int _duration;
    private DateTime _now;
    protected DateTime _finish;
    protected Random giveMeRandom = new Random();
    private void LoadCharacter()
    {
        //Used in the OpeningDisplay
        Console.Write(" ");
        Thread.Sleep(200);
        Console.Write("\b@\b");
    }
    private void WriteCharacter()
    {
        //Used in the ClosingDisplay
        Console.Write("@");
        Thread.Sleep(400);
    }

    public Activity(string name, int duration)
    {
        //Constructor that will always be used
        _name = name;
        _duration = duration;
    }

    public void InitializeTime()
    {
        //This is just to set these values, it could be combined with opening display
        _now = DateTime.Now;
        _finish = DateTime.Now.AddSeconds(_duration);
    }
    public void OpeningDisplay()
    {
        Console.Clear();
        Console.WriteLine($"------Welcome to the {_name} activity!-----\n");
        Console.WriteLine(_description);

        //Waiting interface (A little fancy)
        Console.WriteLine("-----######@@@######-----");
        Console.WriteLine("-----#####@###@#####-----");
        Console.WriteLine("-----####@#####@####-----");
        Console.WriteLine("-----#####@###@#####-----");
        Console.WriteLine("-----######@@@######-----");

        int currentrow = Console.CursorTop;

        //Goes round and round
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(12, currentrow - 5);
            LoadCharacter();
            Console.SetCursorPosition(13, currentrow - 5);
            LoadCharacter();
            Console.SetCursorPosition(14, currentrow - 4);
            LoadCharacter();
            Console.SetCursorPosition(15, currentrow - 3);
            LoadCharacter();
            Console.SetCursorPosition(14, currentrow - 2);
            LoadCharacter();
            Console.SetCursorPosition(13, currentrow - 1);
            LoadCharacter();
            Console.SetCursorPosition(12, currentrow - 1);
            LoadCharacter();
            Console.SetCursorPosition(11, currentrow - 1);
            LoadCharacter();
            Console.SetCursorPosition(10, currentrow - 2);
            LoadCharacter();
            Console.SetCursorPosition(9, currentrow - 3);
            LoadCharacter();
            Console.SetCursorPosition(10, currentrow - 4);
            LoadCharacter();
            Console.SetCursorPosition(11, currentrow - 5);
            LoadCharacter();
        }
        Console.SetCursorPosition(0, currentrow);
    }

    public void ClosingDisplay()
    {
        TimeSpan actualTime = DateTime.Now - _now; //This piece of code does the math and returns the difference
        Console.Clear();
        Console.WriteLine($"You have done a great job completing the {_name} activty!");
        Console.WriteLine($"You spent {actualTime.TotalSeconds} seconds in the {_name} activty!");

        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");
        Console.WriteLine("-------------------------");

        int currentrow = Console.CursorTop;

        //Suprise Animation (it's kinda creepy on accident)
        Console.SetCursorPosition(11, currentrow - 5);
        WriteCharacter();
        Console.SetCursorPosition(15, currentrow - 5);
        WriteCharacter();
        Console.SetCursorPosition(9, currentrow - 3);
        WriteCharacter();
        Console.SetCursorPosition(10, currentrow - 2);
        WriteCharacter();
        Console.SetCursorPosition(11, currentrow - 2);
        WriteCharacter();
        Console.SetCursorPosition(12, currentrow - 1);
        WriteCharacter();
        Console.SetCursorPosition(13, currentrow - 1);
        WriteCharacter();
        Console.SetCursorPosition(14, currentrow - 1);
        WriteCharacter();
        Console.SetCursorPosition(15, currentrow - 2);
        WriteCharacter();
        Console.SetCursorPosition(16, currentrow - 2);
        WriteCharacter();
        Console.SetCursorPosition(17, currentrow - 3);
        WriteCharacter();

        Thread.Sleep(2000);
    }
}