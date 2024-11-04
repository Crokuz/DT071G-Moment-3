/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 3
*/

namespace Moment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var postManager = new PostManager();
            // Loads posts from json-file if available
            postManager.LoadPosts(); 

            bool displayMenu = true;
            while (displayMenu)
            {
                // Displays user interface
                displayMenu = UserInterface.DisplayMenu(postManager);
            }
        }
    }
}
