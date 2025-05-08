using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class Player
    {
        private List<Card> hand;
        private int score;

        public Player()
        {
            hand = new List<Card>();
            score = 0;
        }

        public void DrawCard(Deck deck)
        {
            Card drawnCard = deck.DrawCard();
            if (drawnCard != null)
            {
                hand.Add(drawnCard);
            }
        }

        public void DiscardCard(Card card)
        {
            hand.Remove(card);
        }

        public int GetScore()
        {
            return score;
        }

        public void IncrementScore()
        {
            score++;
        }

        public List<Card> GetHand()
        {
            return hand;
        }
    }
}
