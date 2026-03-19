public class EternalGoal : Goal
{
    public EternalGoal(string name, string description) : base(name, description)
    {
        base.SetComplete(false);
        _pointsAwarded = 100;
    }

    public override void MarkComplete()
    {
        _timesCompleted += 1;
        AddPoints();
    }
    public override void AddPoints()
    {
        base.SetScore(base.GetScore() + _pointsAwarded);
    }
    public override void PrintDetails()
    {
        Console.Write($"Name: {base.GetName()}\nDescription: {base.GetDescription()}\nTimes Completed: {_timesCompleted}\nPoints Earned from this Goal: {base.GetScore()}\n");
    }
}