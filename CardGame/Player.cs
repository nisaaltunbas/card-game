using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { private get; set; }
        public int CardCount { get; set; }
        public int Points
        {
            get
            {
                int total = collected.Sum(card => card.Points);
                if (HasMostCards)
                {
                    total += 3;
                }
                return total +  CardCount * 10;
            }
        }

        private List<Card> collected;
        public int CollectedCount { get { return collected.Count; } }

        public bool HasMostCards { get; set; }

        private Random random = new Random();

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            collected = new List<Card>();
            CardCount = 0;
            HasMostCards = false;
        }

        public Card PlayCard()
        {
            int i = random.Next(Hand.Count);
            Card cardToPlay = Hand[i];
            Hand.RemoveAt(i);
            return cardToPlay;
        }

        public void Collect(List<Card> place)
        {
            collected.AddRange(place);
        }

        public override string ToString()
        {
            return $"{Name} ({Points}p):\n" +
                   $"Pisti Count: {CardCount}\n" +
                   $"Has Most Cards: {HasMostCards}\n" +
                   $"Hand ({Hand.Count}): {string.Join(", ", Hand)}\n" +
                   $"Collected ({collected.Count}): {string.Join(", ", collected)}";
        }
    }
}
