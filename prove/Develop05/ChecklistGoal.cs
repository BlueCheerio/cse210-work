public class ChecklistGoal : Goal
{
    private int _timesToComplete;

    public ChecklistGoal(string name, string description, int timesToComplete) : base(name, description)
    {
        base.SetComplete(false);
        _timesToComplete = timesToComplete;
        _pointsAwarded = 50;
    }

    public override void MarkComplete()
    {
        _timesCompleted += 1;
        AddPoints();
    }
    public override void AddPoints()
    {
        if (_timesCompleted < _timesToComplete)
        {
            base.SetScore(base.GetScore() + _pointsAwarded);
        }
        else if (_timesCompleted == _timesToComplete)
        {
            base.SetScore(base.GetScore() + _pointsAwarded * 10);
            base.SetComplete(false);
            base.SetDateCompleted(DateTime.Now);
        }
    }
    public override void PrintDetails()
    {
        Console.Write($"Name: {base.GetName()}\nDescription: {base.GetDescription()}\nCompleted: {_timesCompleted} times\nPoints Earned from this Goal: {base.GetScore()}\nComplete: {base.CheckComplete()}");
        if (!base.CheckComplete())
        {
            Console.WriteLine($"Need to complete {_timesToComplete} more times to reach the milestone!\n");
        }
        else
        {
            Console.WriteLine($"Date Milestone was reached: {base.GetDateCompleted()}\n");
        }
    }

    //These 2 functions are only used when saving and loading a ChecklistGoal
    public int GetTimesToComplete()
    {
        return _timesToComplete;
    }
    public void SetTimesToComplete(int timesToComplete)
    {
        _timesToComplete = timesToComplete;
    }

}