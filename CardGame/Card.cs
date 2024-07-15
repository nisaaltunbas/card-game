using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Card
    {
        private string suit;

        public string Suit { get { return suit; } }

        private string value;
        public string Value { get { return value; } }

        public int Points
        {
            get
            {
                if (value == "Jack" || value == "Ace")
                {
                    return 1;
                }
                else if (value == "2" && suit == "Clubs")
                {
                    return 2;
                }
                else if (value == "10" && suit == "Diamonds")
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Card(string suit, string value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString()
        {
            return $"| {suit} {value} ({Points}) |";
        }
    }
}