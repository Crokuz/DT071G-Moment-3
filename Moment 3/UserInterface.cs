/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 3
*/

namespace Moment_3;

// Class for managing UI and user interaction
class UserInterface
{
    // Prints menu
    public static bool DisplayMenu(PostManager postManager)
    {
        Console.Clear();

        Console.WriteLine("GUESTBOOK \r\n");
        Console.WriteLine("1. Write in guestbook");
        Console.WriteLine("2. Remove post");
        Console.WriteLine("X. Close guestbook \r\n");

        postManager.DisplayPosts();

        switch (Console.ReadLine())
        {
            case "1":
                WritePost(postManager);
                return true;

            case "2":
                DeletePost(postManager);
                return true;

            case "x":
                return false;

            default:
                Console.WriteLine("Invalid command input.");
                return true;
        }
    }

    // Manages input for creating new post
    private static void WritePost(PostManager postManager)
    {
        Console.Clear();

        string name = ValidateInput("What's your name?");
        string message = ValidateInput("What's your message?");

        postManager.AddPost(name, message);
        postManager.SavePosts();
    }

    // Manages input for removal of post
    private static void DeletePost(PostManager postManager)
    {
        Console.Clear();

        postManager.DisplayPosts();

        Console.WriteLine("\r\nWhich post do you want to delete (write corresponding index)?");

        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            postManager.RemovePost(id);
            postManager.SavePosts();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.Write("\r\nPress Enter to return to the Main Menu");
        Console.ReadLine();
    }

    // Validates user unput
    public static string ValidateInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
}
