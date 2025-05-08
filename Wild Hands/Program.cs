/*
 * Tyler Hitchcock
 * 4/2/25
 * credits: help from my brother
*/

namespace Wild_Hands
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Wild Hands by Tyler Hitchcock";
            Console.WriteLine("Welcome to Wild Hands!");

            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"
                   _______
                  |A      |
                  |   /\   |
                  |  /  \  |
                  |  |  |  |
                  |   \/   |
                  |       A|
                   -------
                ");
                Console.ResetColor();
                Console.WriteLine("Choose a game to play:");
                Console.WriteLine("1. Same or Different?");
                Console.WriteLine("2. Higher or Lower?");
                Console.WriteLine("3. Highest Match");
                Console.WriteLine("Enter your choice (1-3): ");

                int choice;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);

                if (validChoice)
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            SameOrDifferent sameOrDifferent = new SameOrDifferent();
                            sameOrDifferent.StartGame();
                            break;
                        case 2:
                            HigherOrLower higherOrLower = new HigherOrLower();
                            higherOrLower.StartGame();
                            break;
                        case 3:
                            HighestMatchGame highestMatchGame = new HighestMatchGame();
                            highestMatchGame.StartGame();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Exiting...");
                            break;
                    }

                    // Ask if the player wants to play again
                    Console.WriteLine("\nDo you want to play another game? (yes/no): ");
                    string userResponse = Console.ReadLine().Trim().ToLower();

                    if (userResponse == "no")
                    {
                        playAgain = false;
                        Console.WriteLine("Thanks for playing!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                }
            }
        }
    }
}
            

