/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 3
*/

using System.Text.Json;

namespace Moment_3;

// Class for managing posts
class PostManager
{
    private List<Post> postList = new List<Post>();

    // Adds new post to list
    public void AddPost(string name, string message)
    {
        Post post = new Post(name, message);
        postList.Add(post);
    }

    // Removes post of corresponding index
    public void RemovePost(int index)
    {
        if (index >= 0 && index < postList.Count)
        {
            postList.RemoveAt(index);
            Console.WriteLine($"Post [{index}] removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid post index.");
        }
    }

    // Displays all posts
    public void DisplayPosts()
    {
        for (int i = 0; i < postList.Count; i++)

        {
            Console.WriteLine($"[{i}] {postList[i]}");
        }
        Console.WriteLine($"Number of posts: {postList.Count}");
    }

    // Serializes the list of posts and saves them to a json-file
    public void SavePosts()
    {
        try
        {
            string json = JsonSerializer.Serialize(postList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("data.json", json);
            Console.WriteLine("Data successfully saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving data: {ex.Message}");
        }
    }

    // Deserializes the json-file to a list 
    public void LoadPosts()
    {
        try
        {
            if (File.Exists("data.json"))
            {
                string json = File.ReadAllText("data.json");
                postList = JsonSerializer.Deserialize<List<Post>>(json);
                Console.WriteLine("Data loaded from data.json");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading data: {ex.Message}");
        }
    }
}