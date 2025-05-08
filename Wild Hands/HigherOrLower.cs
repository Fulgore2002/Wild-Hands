using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class HigherOrLower : Game
    {
        public override void StartGame()
        {
            deck.Shuffle();
            Console.WriteLine("Welcome to Higher or Lower!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@" 
     /\
   .'  `.
  '      `.
<          >
 `.      .'
   `.  .'
     \/
");
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
            Console.WriteLine($"The card is: {previousCard.GetValue()}");

            for (int round = 1; round <= totalRounds; round++)
            {
                if (!deck.HasMoreCards())
                {
                    Console.WriteLine("Deck is empty before completing all rounds!");
                    break;
                }
                Console.Write($"Round {round}/{totalRounds} - Will the next card be higher or lower? (Enter 'higher' or 'lower'): ");
                string guess = Console.ReadLine().Trim().ToLower();

                Card currentCard = deck.DrawCard();
                if (currentCard == null)
                    break;

                Console.WriteLine($"The next card is: {currentCard.GetValue()}");
                int comparison = currentCard.GetValue().CompareTo(previousCard.GetValue());
                if ((guess == "higher" && comparison > 0) || (guess == "lower" && comparison < 0))
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
