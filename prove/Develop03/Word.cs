using System.Diagnostics;

public class Word
{
    private bool hidden;
    private List<char> letters = new List<char>();
    private List<char> hiddenletters = new List<char>();
    public string _itself;

    //Word initialization
    public Word(string wholeword)
    {
        _itself = wholeword;
        foreach (char c in _itself)
        {
            letters.Add(c);
        }
    }

    //Tell the Scripture program if the scripture is hidden or not
    public bool CheckHidden()
    {
        return hidden;
    }

    //Printing out each word, hidden or not
    public void DisplayWord()
    {
        Console.Write(_itself + " ");
    }

    //We actually don't use this, but if we hypothetically had the program continue after the scripture
    //is blank I would have it "reconstruct" each word before putting it back into the VisibleWords list.
    //I would also use this if we were to add something like a "hint" button to make some words reappear.
    public void MakeVisible()
    {
        hidden = false;
        for (int i = 0; i < hiddenletters.Count; i++)
        {
            letters[i] = hiddenletters[i];
        }
        hiddenletters.Clear();
        _itself = new string (letters.ToArray());
    }

    //This makes a word "hidden" or in reality it just because a bunch of underscores
    public void MakeHidden()
    {
        hidden = true;
        letters.Clear();
        foreach (char letter in _itself)
        {
            hiddenletters.Add(letter);
            letters.Add('_');
        }
        _itself = new string (letters.ToArray());
    }

}