public class Prompt
{
    private string _prompt;

    public void GeneratePrompt()
    {
        // Gives a randomly generated prompt to the user for them to respond to, it both saves the value to itself and prints it
        string prompt = "Blank";
        Random randomm = new Random();
        int randomnumber = randomm.Next(10);
        if (randomnumber == 0) prompt = "What was your highlight of the day?";
        else if (randomnumber == 1) prompt = "What was your funniest moment/interaction of the day?";
        else if (randomnumber == 2) prompt = "How did you see God's hand in your life today?";
        else if (randomnumber == 3) prompt = "Did you meet anyone new? Who were they? What did you learn about them?";
        else if (randomnumber == 4) prompt = "If you could change one thing about today what would you change?";
        else if (randomnumber == 5) prompt = "What is something fascinating that you learned today?";
        else if (randomnumber == 6) prompt = "What made you laugh the most today?";
        else if (randomnumber == 7) prompt = "What progress did you make on your personal goals today?";
        else if (randomnumber == 8) prompt = "Who did you serve today? Who will you serve tomorrow and how?";
        else if (randomnumber == 9) prompt = "What promptings did you recieve from the spirit today? How did you follow them?";
        _prompt = prompt;
        Console.WriteLine(_prompt);
    }

    public void SetPrompt(string prompt)
    {
        _prompt = prompt;
    }
    public string GetPrompt()
    {
        return _prompt;
    }
    public void PrintSelf()
    {
        Console.WriteLine(_prompt);
    }

}