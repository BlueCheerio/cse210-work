public class Listening : Activity
{
    private List<string> _prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _userInputs = new List<string>();
    public Listening(string name, int duration) : base(name, duration)
    {
        //The activty runs straight from the constructor
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        OpeningDisplay();
        InitializeTime();
        Console.WriteLine("Think about some answers (When the time runs out write as many as you can think of)");
        for(int i = 5; i > 0; i--)
        {
            //Waiting display
            Console.Write(i);
            for (int c = 0; c < 4; c++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
            Console.Write("\b\b\b\b\b     \b\b\b\b\b");
        }

        while(true)
        {
            //Actual listening activity
            if(_now<_finish)
            {
                _userInputs.Add(Console.ReadLine());
            }
            else
            {
                break;
            }
        }
        Thread.Sleep(250);
        Console.Clear();
        Console.WriteLine("-----Times Up!-----");
        Console.WriteLine($"You entered {_userInputs.Count} items");
        Thread.Sleep(3000);
        ClosingDisplay();
    }
}