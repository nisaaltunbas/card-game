using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Table
    {
        public Deck GameDeck;
        public Player[] Players { get; set; }
        public List<Card> Place { get; set; }
        private int lastPlayerToTakeTurnIndex;

        public Table(int playerCount)
        {
            GameDeck = new Deck();
            Players = new Player[playerCount];
            Place = new List<Card>();
            for (int i = 0; i < playerCount; i++)
            {
                Players[i] = new Player($"Player {i + 1}");
            }
            Place = GameDeck.DealCards(4);
            //Distribute();
            //PlayRound();
            PlayGame();
        }

        public void Distribute()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].Hand = GameDeck.DealCards(4);
            }
        }

        public void PlayRound()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Players.Length; j++)
                {
                    Card playedCard = Players[j].PlayCard();
                    if (ApplyRule(playedCard))
                    {
                        if (IsCard(playedCard))
                        {
                            Players[j].CardCount++;
                        }
                        Place.Add(playedCard);
                        Players[j].Collect(Place);
                        Place.Clear();
                        lastPlayerToTakeTurnIndex = j;
                    }
                    else
                    {
                        Place.Add(playedCard);
                    }
                }
            }
        }

        public void PlayGame()
        {
            while (GameDeck.Cards.Count > 0)
            {
                Distribute();
                PlayRound();
            }
            Players[lastPlayerToTakeTurnIndex].Collect(Place);
            Place.Clear();
            int playerWithMostCardsIndex = 0;
            for (int i = 1; i < Players.Length; i++)
            {
                if (Players[playerWithMostCardsIndex].CollectedCount < Players[i].CollectedCount)
                {
                    playerWithMostCardsIndex = i;
                }
            }
            Players[playerWithMostCardsIndex].HasMostCards = true;
        }

        public bool ApplyRule(Card playedCard)
        {
            if (Place.Count > 0)
            {
                Card topCard = Place[Place.Count - 1];
                if (topCard.Value == playedCard.Value || playedCard.Value == "Jack")
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCard(Card playedCard)
        {
            if (Place.Count == 1)
            {
                if (Place[0].Value == playedCard.Value)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{GameDeck}\n\n" +
                   $"Place ({Place.Count}): {string.Join(", ", Place)}\n\n" +
                   $"Players:\n{string.Join("\n\n", Players.ToList())}";
        }
    }
}