using System.Runtime.CompilerServices;
public class Reference
{
    private string _reference;
    private int _scripturenumber;
    private int _numberofverses;
    private Random randomm = new Random();

    public Reference(Dictionary<int, List<string>> Scriptures)
    {
        _scripturenumber = randomm.Next(Scriptures.Count);
        _reference = Scriptures[_scripturenumber][0];
        _numberofverses = Scriptures[_scripturenumber].Count - 1; //This handles the case where there could be multiple verses
    }

    public Reference(string reference, string verse, Dictionary<int, List<string>> Scriptures)
    {
        _reference = reference;
        Scriptures.Add(Scriptures.Count, new List<string>{_reference, verse});

        //If the user wants to memorize multiple verses they need to input them seperately (makes it easy to organize)
        //I put this in a constructor because it is unique to the reference handling multiple verses
        if (_numberofverses > 1)
        {
            for (int i = 1; i < _numberofverses; i++)
            {
                Console.WriteLine("Please input the next verse: ");
                Scriptures[Scriptures.Count - 1].Add(Console.ReadLine());
            }
        }
    }

    public int GetScriptureNumber()
    {
        return _scripturenumber;
    }

    public int GetNumberVerses()
    {
        return _numberofverses;
    }
    public void SetReference(string reference)
    {
        _reference = reference;
    }
    public string GetReference()
    {
        return _reference;
    }
}