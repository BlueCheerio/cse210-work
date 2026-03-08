public class Scripture
{
    private int _numberofwords = 0;
    private List<char> word = new List<char>();

    //This dictionary is overkill but it would allow for the program to be easily added onto in the future.
    //I was dreaming a little beyond my time constraints when I started this program.
    private Dictionary<int, Word> WordsinVerse = new Dictionary<int, Word>();
    private List<Word> VisibleWords = new List<Word>();
    private Random randomm = new Random();

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

    //Print out the whole scripture, the function calls each words instance to print itself out
    public void DisplayScripture(Dictionary<int, List<string>> Scriptures, Reference TheReference)
    {
        Console.WriteLine(Scriptures[TheReference.GetScriptureNumber()][0]);
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
    public void MakeScriptureWords(Dictionary<int, List<string>> Scriptures, int versenumber, Reference TheReference)
    {
        string verse = Scriptures[TheReference.GetScriptureNumber()][versenumber];
        string wholeword;
        foreach (char c in verse)
        {
            if (c == ' ')
            {    
                wholeword = new string(word.ToArray());
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

        //We might have to add one more word at the end if there is no space after it
        if (word.Any())
        {
        wholeword = new string(word.ToArray());
        WordsinVerse.Add(_numberofwords, new Word(wholeword));
        VisibleWords.Add(WordsinVerse[_numberofwords]);
        word.Clear();
        _numberofwords++;
        }
    }
}