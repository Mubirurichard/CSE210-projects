using System.Collections.Generic;

public class Video
{
    // Private member variables
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;
    
    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }
    
    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    
    // Method to return number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
    
    // Method to get video information
    public string GetVideoInfo()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds\nComments: {GetNumberOfComments()}";
    }
    
    // Method to get all comments
    public List<string> GetAllComments()
    {
        List<string> commentStrings = new List<string>();
        foreach (Comment comment in _comments)
        {
            commentStrings.Add(comment.GetCommentDisplay());
        }
        return commentStrings;
    }
    
    // Getters (optional)
    public string GetTitle() { return _title; }
    public string GetAuthor() { return _author; }
    public int GetLength() { return _length; }
}