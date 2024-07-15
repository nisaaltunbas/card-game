using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
            string[] suits = { "Spades", "Diamonds", "Clubs", "Hearts" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    Cards.Add(new Card(suits[i], values[j]));
                }
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int firstIndex = random.Next(0, 26); // 0 ~ 25 range
                int secondIndex = random.Next(26, 52); // 26 ~ 51 range

                (Cards[firstIndex], Cards[secondIndex]) = (Cards[secondIndex], Cards[firstIndex]);
            }
        }

        public List<Card> DealCards(int numberOfCards)
        {
            List<Card> dealtCards = Cards.Take(numberOfCards).ToList();
            Cards.RemoveRange(0, numberOfCards);
            return dealtCards;
        }

        public override string ToString()
        {
            return $"Deck ({Cards.Count}): {string.Join(", ", Cards)}";
        }
    }
}
