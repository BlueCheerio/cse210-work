using System.Globalization;

public class Entry
{
    public string _entry = Console.ReadLine();
    public List<string> entrylist = new List<string>();

    // Stores the entry and the prompt together with a date
    public void SaveEntry(string _prompt, string _entry, List<string> entrylist)
    {
        DateTime theCurrentTime = DateTime.Now;
        string _date = theCurrentTime.ToShortDateString();
        entrylist.Add($"{_date}: {_prompt}\n{_entry}");
    }
    
    // Gives a randomly generated prompt to the user for them to respond to
    public string EntryPrompt()
    {
        string _prompt = "Blank";
        Random randomm = new Random();
        int randomnumber = randomm.Next(10);
        if (randomnumber == 0) _prompt = "What was your highlight of the day?";
        else if (randomnumber == 1) _prompt = "What was your funniest moment/interaction of the day?";
        else if (randomnumber == 2) _prompt = "How did you see God's hand in your life today?";
        else if (randomnumber == 3) _prompt = "Did you meet anyone new? Who were they? What did you learn about them?";
        else if (randomnumber == 4) _prompt = "If you could change one thing about today what would you change?";
        else if (randomnumber == 5) _prompt = "What is something fascinating that you learned today?";
        else if (randomnumber == 6) _prompt = "What made you laugh the most today?";
        else if (randomnumber == 7) _prompt = "What progress did you make on your personal goals today?";
        else if (randomnumber == 8) _prompt = "Who did you serve today? Who will you serve tomorrow and how?";
        else if (randomnumber == 9) _prompt = "What promptings did you recieve from the spirit today? How did you follow them?";
        return _prompt;
    }

    // Prints out each entry in the current journal
    public void EntryPrint(List<string> entrylist)
    {
        foreach (string entry in entrylist)
        {
            Console.WriteLine(entry);
        }
    }
}