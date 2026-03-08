using System.ComponentModel;

public class Breathing : Activity
{
    public Breathing(string name, int duration) : base(name, duration)
    {
        //I decided that I don't actually need a run function, we can simply run the class when it is constructed
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        OpeningDisplay();
        InitializeTime();

        while(true)
        {
            //The Breathing Activity
            if (DateTime.Now < _finish)
            {
                Console.WriteLine("Breath in...");
                Console.Write(5);
                for (int i = 4; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    Console.Write($"\b{i}");
                }
                Console.Write($"\b \b");
            }
            else
            {
                break;
            }
            if (DateTime.Now < _finish)
            {
                Console.WriteLine("Breath out...");
                Console.Write(5);
                for (int i = 4; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    Console.Write($"\b{i}");
                }
                Console.Write($"\b \b");
            }
            else
            {
                break;
            }
        }
        ClosingDisplay();   
    }

}