public class Comment
{
    // Private member variables
    private string _name;
    private string _text;
    
    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
    
    // Method to get comment display text
    public string GetCommentDisplay()
    {
        return $"{_name}: {_text}";
    }
    
    // Getters (optional but good for encapsulation)
    public string GetName()
    {
        return _name;
    }
    
    public string GetText()
    {
        return _text;
    }
}