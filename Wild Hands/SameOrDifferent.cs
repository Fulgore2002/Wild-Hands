using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class SameOrDifferent : Game
    {
        public SameOrDifferent() : base()
        {
            string[] twoSuits = { "Hearts", "Spades" };
            deck = new Deck(twoSuits);
        }

        public override void StartGame()
        {
            deck.Shuffle();
            Console.WriteLine("Welcome to Same or Different!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
     .-~~-.
    {      }
 .-~-.    .-~-.
{              }
 `.__.'||`.__.'
       ||
      '--` ");
            Console.ResetColor();
            PlayRound();
        }

        public override void PlayRound()
        {
            int totalRounds = 10;
            Console.WriteLine("Drawing the first card...");
            Card previousCard = deck.DrawCard();
            if (previousCard == null)
            {
                Console.WriteLine("Deck is empty!");
                EndGame();
                return;
            }
            Console.WriteLine($"The card is: {previousCard.GetSuit()}");

            for (int round = 1; round <= totalRounds; round++)
            {
                if (!deck.HasMoreCards())
                {
                    Console.WriteLine("Deck is empty before completing all rounds!");
                    break;
                }
                Console.Write($"Round {round}/{totalRounds} - Will the next card be the same suit or different? (Enter 'same' or 'different'): ");
                string guess = Console.ReadLine().Trim().ToLower();

                Card currentCard = deck.DrawCard();
                if (currentCard == null)
                    break;

                Console.WriteLine($"The next card is: {currentCard.GetSuit()}");
                bool isSame = previousCard.GetSuit() == currentCard.GetSuit();
                if ((guess == "same" && isSame) || (guess == "different" && !isSame))
                {
                    Console.WriteLine("Correct guess!");
                    player.IncrementScore();
                }
                else
                {
                    Console.WriteLine("Wrong guess!");
                }
                previousCard = currentCard;
            }
            EndGame();
        }

        public override void EndGame()
        {
            int finalScore = player.GetScore();
            Console.WriteLine("Final Score: " + finalScore);

            int threshold = 10;
            if (finalScore >= threshold)
            {
                Console.WriteLine("You've won!");
            }
            else
            {
                Console.WriteLine("Better luck next time.");
            }
            Console.WriteLine("Thank you for playing!");
        }
    }
}
