using System.Diagnostics.Contracts;

public abstract class Goal
{
    private int _pointsEarned;
    private string _name;
    private string _description;
    private DateTime _dateCompleted;
    protected int _pointsAwarded;

    //These two variables are used in 2 classes each and so they are passed and set in those classes when needed
    protected int _timesCompleted;
    protected bool _complete;

    public Goal(string name, string description)
    {
        _name = name;
        _description = description;
        _pointsEarned = 0;
        _timesCompleted = 0;

    }

    public virtual void PrintDetails(){}
    public virtual void AddPoints(){}

    public virtual void MarkComplete()
    {
        AddPoints();
        _complete = true;
        _dateCompleted = DateTime.Now;
    }
    public DateTime GetTimeCompleted()
    {
        return _dateCompleted;
    }
    public void SetTimeCompleted(DateTime timeCompleted)
    {
        _dateCompleted = timeCompleted;
    }
    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public bool CheckComplete()
    {
        return _complete;
    }

    public string GetName()
    {
        return _name;
    }
    public int GetScore()
    {
        return _pointsEarned;
    }
    public int GetPointsAwarded()
    {
        return _pointsAwarded;
    }
    public void SetScore(int points)
    {
        _pointsEarned = points;
    }
    public string GetDescription()
    {
        return _description;
    }


}