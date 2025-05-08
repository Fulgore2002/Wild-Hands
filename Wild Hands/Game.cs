using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Hands
{
    public class Game
    {
        protected Deck deck;
        protected Player player;

        public Game()
        {
            deck = new Deck();
            player = new Player();
        }

        public virtual void StartGame()
        {
            deck.Shuffle();
            Console.WriteLine("Game started!");
        }

        public virtual void PlayRound() { }

        public virtual void EndGame()
        {
            Console.WriteLine("Game over! Final score: " + player.GetScore());
        }
    }
}
