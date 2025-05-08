using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            InitializeDeck();
        }

        public Deck(string[] selectedSuits)
        {
            cards = new List<Card>();
            InitializeDeck(selectedSuits);
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0) return null;
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void ResetDeck()
        {
            cards.Clear();
            InitializeDeck();
        }

        public bool HasMoreCards()
        {
            return cards.Count > 0;
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int i = 1; i <= 13; i++)
            {
                foreach (string suit in suits)
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }


        private void InitializeDeck(string[] suits)
        {
            for (int i = 1; i <= 13; i++)
            {
                foreach (string suit in suits)
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }
    }
}
