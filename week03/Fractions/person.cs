using System;

public class Person
{
    // Private member variables
    private string _title;
    private string _firstName;
    private string _lastName;

    // Constructors
    public Person()
    {
        _title = "";
        _firstName = "";
        _lastName = "";
    }

    public Person(string first, string last)
    {
        _title = "";
        _firstName = first;
        _lastName = last;
    }

    public Person(string title, string first, string last)
    {
        _title = title;
        _firstName = first;
        _lastName = last;
    }

    // Public methods
    public string GetInformalSignature()
    {
        return "Thanks, " + _firstName;
    }

    public string GetFormalSignature()
    {
        return "Sincerely, " + GetFullName();
    }

    // Private helper method (encapsulated)
    private string GetFullName()
    {
        string fullName = "";
        
        if (!string.IsNullOrEmpty(_title))
        {
            fullName += _title + " ";
        }
        
        fullName += _firstName + " " + _lastName;
        
        return fullName.Trim();
    }

    // Getters and Setters (optional - only if needed)
    public string GetFirstName()
    {
        return _firstName;
    }

    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
    }

    public string GetLastName()
    {
        return _lastName;
    }

    public void SetLastName(string lastName)
    {
        _lastName = lastName;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }
}