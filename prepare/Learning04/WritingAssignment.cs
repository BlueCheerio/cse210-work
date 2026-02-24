public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string title, string topic, string studentname) : base(studentname, topic)
    {
        _title = title;
    }

    public void GetWritingInformation()
    {
        Console.WriteLine(_title);
    }
}