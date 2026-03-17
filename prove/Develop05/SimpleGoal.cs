using System.Runtime.InteropServices;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description) : base(name, description)
    {
        _complete = false;
        _pointsAwarded = 500;
    }

    public override void AddPoints()
    {
        base.SetScore(base.GetScore() + _pointsAwarded);
    }
    public override void PrintDetails()
    {
        Console.Write($"Name: {base.GetName()}\nDescription: {base.GetDescription()}\nComplete: {base.CheckComplete()}\nPoints Earned from this Goal: {base.GetScore()}\n");
        if (base.CheckComplete())
        {
            Console.WriteLine($"Date Completed: {base.GetTimeCompleted()}\n");
        }
        else
        {
            Console.WriteLine("\n");
        }
    }
}