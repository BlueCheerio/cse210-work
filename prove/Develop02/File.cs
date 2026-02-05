using System.Reflection.Metadata;
using System.IO;

public class FileOrganize
{
    //Upload a file to a list that can be printed out later
    public void LoadFile(List<string> entrylist)
    {
        bool userchoice = true;
        while (userchoice)    //Making sure that the user is chill with deleting all the current entries
        {
            Console.WriteLine("Uploading a journal will delete any current entries, make sure they are saved! Are you sure you want to upload a journal? (y/n):\n");
            string input = Console.ReadLine();
            if (input == "y")
            {
                userchoice = false;
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
        entrylist.Clear();    //This deletes everything from the previous journal (hopefully they chose to save it)
        Console.WriteLine("What is the name of the journal you would like to upload? (Please be exact)\n");
        string userinput = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(userinput);
        foreach (string line in lines)
        {
            entrylist.Add(line);
        }
        Console.WriteLine("-----Journal Uploaded!-----");
    }

    //Saves the current file to a name given by the user
    public void SaveFile(List<string> entrylist)
    {
        Console.WriteLine("Please type an exact journal name: ");
        string userinput = Console.ReadLine();
        if (userinput.Contains(".txt"))          // I looked up this particular piece of code to make sure that a file is created no matter what
        {
            Console.WriteLine();
        }
        else
        {
            userinput = userinput + ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(userinput))
        {
            foreach (string line in entrylist)
            {
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine("\n-----Journal Saved!-----\n");

    }
}