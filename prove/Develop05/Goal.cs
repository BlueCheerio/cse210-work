using System.Diagnostics.Contracts;

public abstract class Goal
{
    private int _pointsEarned; //This is just a cool varibale to caculate the amount of points a goal has given a player, it is not the total score
    private string _name;
    private string _description;
    private bool _complete;
    private string _dateCompleted;
    protected int _timesCompleted; //This variable and the next get called so many times I'll just set them protected
    protected int _pointsAwarded; //This is how many points a player will earn if they complete the goal


    public Goal(string name, string description)
    {
        _name = name;
        _description = description;
        _pointsEarned = 0;

    }

    //Our virtual functions that each child class uses
    public virtual void PrintDetails(){}
    public virtual void AddPoints(){}

    public virtual void MarkComplete()
    {
        AddPoints();
        _complete = true;
        _dateCompleted = DateTime.Now.ToString();
    }

    //Getters
    public string GetDateCompleted()
    {
        return _dateCompleted;
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
    public string GetDescription()
    {
        return _description;
    }
    public int GetScore()
    {
        return _pointsEarned;
    }
    public int GetPointsAwarded()
    {
        return _pointsAwarded;
    }

    //Setters
    public void SetDateCompleted(string dateCompleted)
    {
        _dateCompleted = dateCompleted;
    }
    public void SetTimesCompleted(int timesCompleted)
    {
        
    }
    public void SetScore(int points)
    {
        _pointsEarned = points;
    }
    public void SetComplete(bool complete)
    {
        //Slightly different from Mark complete, which adds points to the points earned variable
        _complete = complete;
    }


}