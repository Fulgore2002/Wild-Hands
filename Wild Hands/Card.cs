using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class Card
    {
        // Attributes
        private string suit;
        private int value;

        // Constructor
        public Card(string suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        // Methods to get the attributes
        public string GetSuit()
        {
            return suit;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
