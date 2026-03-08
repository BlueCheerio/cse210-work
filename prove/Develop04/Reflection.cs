public class Reflection : Activity
{
    private List<string> _prompts = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public Reflection(string name, int duration) : base(name, duration)
    {
        //We don't need to call a function when the instance can just run itself
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        OpeningDisplay();
        InitializeTime();
        Console.WriteLine(_prompts[giveMeRandom.Next(_prompts.Count)]);
       
        while(true)
        {
            //The actual Reflection activity
            if(DateTime.Now < _finish)
            {
                Console.WriteLine(_questions[giveMeRandom.Next(_questions.Count)]);
            }
            else
            {
                break;
            }

            //Thinking animation
            for(int i = 0; i < 10; i++)
            {
                //A double check while loading
                if(DateTime.Now < _finish)
                {
                    Console.Write("-");
                    Thread.Sleep(250);
                    Console.Write("\b\\");
                    Thread.Sleep(250);
                    Console.Write("\b|");
                    Thread.Sleep(250);
                    Console.Write("\b/");
                    Thread.Sleep(250);
                    Console.Write("\b \b");
                }
                else
                {
                    break;
                }
            }
        }
        ClosingDisplay();
    }
}