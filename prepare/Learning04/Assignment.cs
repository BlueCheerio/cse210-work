public class Assignment
{
    private string _studentName;
    private string _topic;

    

    public Assignment(string studentname, string topic)
    {
        _studentName = studentname;
        _topic = topic;
    }

    public void GetSummary()
    {
        Console.WriteLine($"{_studentName} - {_topic}");
    }
}