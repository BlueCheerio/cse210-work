using System.Globalization;

public class Entry
{
    private string _entry;

    public void SetEntry(string entry)
    {
        _entry = entry;
    }
    public string GetEntry()
    {
        return _entry;
    }

    public void PrintSelf()
    {
        Console.WriteLine(_entry);
    }
}