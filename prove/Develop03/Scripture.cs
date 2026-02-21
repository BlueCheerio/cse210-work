public class Scripture
{
    private int _scripturenumber;
    private int _numberofverses;
    private int _numberofwords = 0;
    private List<char> word = new List<char>();

    //This dictionary is overkill but it would allow for the program to be easily added onto in the future.
    //I was dreaming a little beyond my time constraints when I started this program.
    private Dictionary<int, Word> WordsinVerse = new Dictionary<int, Word>();
    private List<Word> VisibleWords = new List<Word>();
    private Random randomm = new Random();

    //Constructor #1, the default constructor if the user doesn't input a custom scripture
    public Scripture(Dictionary<int, List<string>> Scriptures)
    {
        _scripturenumber = randomm.Next(Scriptures.Count);
        _numberofverses = Scriptures[_scripturenumber].Count - 1;   
    }

    //Constructor #2, sets up the scripture if the user wants to input their own
    public Scripture(string reference, string verse, Dictionary<int, List<string>> Scriptures)
    {
        _scripturenumber = Scriptures.Count;
        Scriptures.Add(Scriptures.Count, new List<string>{reference, verse});
    }

    //We check to see if there are still words to hide here, if not it will return a false value that will make the program end.
    public bool StillWordsLeft()
    {
        if (VisibleWords.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //We only use this when Constructor #1 is called, if the user creates their own scripture
    //the number of verses is kept in the Program class.
    public int GetNumberVerses()
    {
        return _numberofverses;
    }

    //Print out the whole scripture, the function calls each words instance to print itself out
    public void DisplayScripture(Dictionary<int, List<string>> Scriptures)
    {
        Console.WriteLine(Scriptures[_scripturenumber][0]);
        for (int i = 0; i < WordsinVerse.Count; i++)
        {
            WordsinVerse[i].DisplayWord();
        }
    }

    //Set a random number of random words to an invisible state within the scripture
    public void SetWordsInvisible()
    {
        int werevisible;
        if (WordsinVerse.Count >= 6)
        {
            if (VisibleWords.Count >= 6)
            {
                werevisible = randomm.Next(6);
            }
            else
            {
                werevisible = VisibleWords.Count;
            }
        }
        else
        {
            werevisible = WordsinVerse.Count;
        }
        for (int i = 0; i < werevisible; i++)
        {
            int goinvisible = randomm.Next(VisibleWords.Count);
            //This is to ensure that we don't keep making the same word "Invisible". This is a little overkill but it
            //could be added onto easily in the future to allow words to reappear easily
            if (!VisibleWords[goinvisible].CheckHidden())
            {
                VisibleWords[goinvisible].MakeHidden();
                VisibleWords.RemoveAt(goinvisible);
            }
        }
    }

    //This will make all instances of the Words in the scripture
    public void MakeScriptureWords(Dictionary<int, List<string>> Scriptures, int versenumber)
    {
        string verse = Scriptures[_scripturenumber][versenumber];
        foreach (char c in verse)
        {
            if (c == ' ')
            {    
                string wholeword = new string(word.ToArray());
                WordsinVerse.Add(_numberofwords, new Word(wholeword));
                VisibleWords.Add(WordsinVerse[_numberofwords]);
                word.Clear();
                _numberofwords++;
            }
            else
            {
                word.Add(c);
            }
        }
    }
}