using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class HighestMatchGame : Game
    {
        private Player dealer;

        public HighestMatchGame() : base()
        {
            dealer = new Player();
        }

        public override void StartGame()
        {
            deck.Shuffle();
            Console.WriteLine("Welcome to Highest Match!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
       /\
     .'  `.
    '      `.
 .'          `.
{              }
 ~-...-||-...-~
       ||
      '--`
");
            Console.ResetColor();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nRound {i + 1}");
                PlayRound();
            }
            EndGame();
        }

        public override void PlayRound()
        {

            Card drawnCard = deck.DrawCard();
            if (drawnCard == null)
            {
                Console.WriteLine("Deck is empty!");
                return;
            }
            Console.WriteLine($"You drew: {drawnCard.GetSuit()} {drawnCard.GetValue()}");
            Console.Write("Do you want to keep this card? (Enter 'keep' or 'discard'): ");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "keep")
            {
                player.GetHand().Add(drawnCard);
            }
            else
            {
                Console.WriteLine("Card discarded.");
            }


            Card dealerCard = deck.DrawCard();
            if (dealerCard != null)
            {
                dealer.GetHand().Add(dealerCard);
            }
        }

        public override void EndGame()
        {
            int playerScore = CalculateHighestSuitValue(player.GetHand());
            int dealerScore = CalculateHighestSuitValue(dealer.GetHand());

            Console.WriteLine("\n--- Final Results ---");
            Console.WriteLine($"Your highest suit score: {playerScore}");
            Console.WriteLine($"Dealer's highest suit score: {dealerScore}");

            if (playerScore > dealerScore)
            {
                Console.WriteLine("You win!");
            }
            else if (playerScore < dealerScore)
            {
                Console.WriteLine("The dealer wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        private int CalculateHighestSuitValue(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
                return 0;

            var suitTotals = cards
                .GroupBy(c => c.GetSuit())
                .Select(g => new { Suit = g.Key, Total = g.Sum(c => c.GetValue()) });

            return suitTotals.Max(s => s.Total);
        }
    }
}
