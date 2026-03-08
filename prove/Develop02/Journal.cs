using System.Reflection.Metadata;
using System.IO;
using System.Numerics;
using System.Dynamic;

public class Journal
{
    //These three lists store the components of the journal, all the entries, prompts, and dates
    private List<Entry> entrylist = new List<Entry>();
    private List<Prompt> promptlist = new List<Prompt>();
    private List<string> datelist = new List<string>();

    //For use when the user wants to respond to a new prompt
    public void NewPrompt()
    {
        promptlist[promptlist.Count] = new Prompt();
        promptlist[promptlist.Count - 1].GeneratePrompt();
    }

    //For use when the user has entered a new entry
    public void NewEntry()
    {
        entrylist[entrylist.Count] = new Entry();
        entrylist[entrylist.Count - 1].SetEntry(Console.ReadLine());
        datelist[datelist.Count] = $"{DateTime.Now}";
    }

    //This function makes the journal display itself
    public void PrintSelf()
    {
        for(int i = 0; i < datelist.Count; i++)
        {
            Console.WriteLine(datelist[i]);
            promptlist[i].PrintSelf();
            entrylist[i].PrintSelf();
        }
    }

    //Upload a file to a list that can be printed out later
    public void LoadJournal()
    {
        while (true)    //Making sure that the user is chill with deleting all the current entries
        {
            Console.WriteLine("Uploading a journal will delete all current entries, make sure they are saved! Are you sure you want to continue? (y/n):\n");
            string input = Console.ReadLine();
            if (input == "y")
            {
                break;
            }
            else if (input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Please type y or n!");
            }
        }

        //This deletes everything from the previous journal lists (hopefully they chose to save it)
        entrylist.Clear();
        promptlist.Clear();
        datelist.Clear();
        
        Console.WriteLine("What is the name of the journal you would like to upload? (You don't have to add .txt)\n");
        string userinput = Console.ReadLine();
        if (userinput.Contains(".txt"))          // I looked up this particular piece of code to make sure that a file is created no matter what
        {
            Console.WriteLine();
        }
        else
        {
            userinput = userinput + ".txt";
        }

        //The actual uploading part where we read the file and create new instances for each part
        string[] lines = System.IO.File.ReadAllLines(userinput);
        int totalLines = 0;
        while (true)
        {
            if (lines.Length < totalLines)
            {
                break;
            }
            else
            {
                datelist.Add(lines[totalLines]);
                totalLines++;
                promptlist[promptlist.Count] = new Prompt();
                promptlist[promptlist.Count - 1].SetPrompt(lines[totalLines]);
                totalLines++;
                entrylist[entrylist.Count] = new Entry();
                entrylist[entrylist.Count - 1].SetEntry(lines[totalLines]);
                totalLines++;
            }
        }
        
        Console.WriteLine("-----Journal Uploaded!-----");
    }

    //Saves the current file to a name given by the user
    public void SaveJournal()
    {
        Console.WriteLine("Please type an exact journal name (you don't need to add .txt): ");
        string userinput = Console.ReadLine();
        if (userinput.Contains(".txt"))          // I looked up this particular piece of code to make sure that a file is created no matter what
        {
            Console.WriteLine();
        }
        else
        {
            userinput = userinput + ".txt";
        }

        //The actual saving part
        using (StreamWriter outputFile = new StreamWriter(userinput))
        {
            //We upload the date, then prompt, then entry, that way we can recover them in the same order
            for (int i = 0; i < entrylist.Count; i++)
            {
                outputFile.WriteLine(datelist[i]);
                outputFile.WriteLine(promptlist[i].GetPrompt());
                outputFile.WriteLine(entrylist[i].GetEntry());
            }
        }
        Console.WriteLine("\n-----Journal Saved!-----\n");

    }
}