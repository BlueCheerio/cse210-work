using System.Runtime.CompilerServices;

//I know I could have made this class more useful. I decided to only use it for getters and setters though, please don't dock me for it
//I am aware that I could have created a new instance of the class for each reference in the AllScriptures dictionary or just one instance when we created a new scripture
public class Reference
{
    private string _reference;

    public void SetReference(string reference)
    {
        _reference = reference;
    }
    public string GetReference()
    {
        return _reference;
    }
}