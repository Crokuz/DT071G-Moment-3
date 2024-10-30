/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 3
*/

namespace Moment_3;

// Class for managing of individual posts
class Post
{
    public string Name { get; set; }
    public string Message { get; set; }

    public Post(string name, string message)
    {
        Name = name;
        Message = message;
    }

    //Overrides ToString() method for easy print-out of post
    public override string ToString()
    {
        return $"{Name}: {Message}";
    }
}    
