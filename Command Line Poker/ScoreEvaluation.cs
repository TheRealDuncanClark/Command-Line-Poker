using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Line_Poker
{
    internal class ScoreEvaluation
    {
        Dictionary<Ranks, int> OfAKind = new Dictionary<Ranks, int>();
        List<Card> scoringCards = new List<Card>();

        public int getScore(Player player)
        {
            player.Hand.OrderByDescending(Card => Card.Rank).ToList();

            findEqualRanks(player);

            if (isRoyalFlush(player))
                return 10;
            if (isStraightFlush(player))
                return 9;
            if (isFourOfAKind(player))
                return 8;
            if (isFullHouse(player))
                return 7;
            if (isFlush(player))
                return 6;
            if (isStraight(player))
                return 5;
            if (isThreeOfAKind(player))
                return 4;
            if (isTwoPair(player))
                return 3;
            if (isOnePair(player))
                return 2;
            if (isHighCard(player))
                return 1;

            return 0;
        }

        public void findEqualRanks(Player player)
        {
            foreach (var card in player.Hand)
            {
                if (OfAKind.ContainsKey(card.Rank))
                {
                    OfAKind[card.Rank]++;
                }
                else
                {
                    OfAKind[card.Rank] = 1;
                }
            }
        }

        public bool isHighCard(Player player)
        {
            scoringCards.Add(player.Hand.OrderByDescending(Card => Card.Rank).First());

            return true;
        }

        public bool isOnePair(Player player)
        {
            int pairs = 0;

            foreach (var count in OfAKind.Values)
            {
                if (count == 2)
                {
                    pairs++;
                }
                else if (count > 2)
                {
                    return false;
                }
            }

            return pairs == 1;
        }
        
        public bool isTwoPair(Player player)
        {
            int pairs = 0;

            foreach (var count in OfAKind.Values)
            {
                if (count == 2)
                {
                    pairs++;
                }
                else if (count > 2)
                {
                    return false;
                }
            }

            return pairs == 2;
        }

        public bool isThreeOfAKind(Player player)
        {
            int trips = 0;

            foreach (var count in OfAKind.Values)
            {
                if (count == 3)
                {
                    trips++;
                }
                else if (count > 3)
                {
                    return false;
                }
            }

            return trips == 1;
        }

        public bool isStraight(Player player)
        {
            int downCount = 0, upCount = 0;

            for (int i = 0; i < 4; i++)
            {
                if (player.Hand[i].Rank == player.Hand[i + 1].Rank - 1)
                {
                    downCount++;
                }
                else if (player.Hand[i].Rank == player.Hand[i + 1].Rank + 1)
                {
                    upCount++;
                }
                else
                {
                    return false;
                }
            }

            if (upCount == 4 || downCount == 4)
            {
                return true;
            }

            return false;
        }

        public bool isFlush(Player player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Hand[i].Suit == player.Hand[i + 1].Suit)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool isFullHouse(Player player)
        {
            int pairs = 0;
            int trips = 0;

            foreach (var count in OfAKind.Values)
            {
                if (count == 2)
                {
                    pairs++;
                }
                if (count == 3)
                {
                    trips++;
                }
            }

            return pairs == 1 && trips == 1;
        }

        public bool isFourOfAKind(Player player)
        {
            foreach (var count in OfAKind.Values)
            {
                if (count == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool isStraightFlush(Player player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Hand[i].Rank == player.Hand[i + 1].Rank - 1 && player.Hand[i].Suit == player.Hand[i + 1].Suit)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool isRoyalFlush(Player player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Hand[i].Rank == player.Hand[i + 1].Rank - 1 && player.Hand[i].Suit == player.Hand[i + 1].Suit)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            if (player.Hand[0].Rank == Ranks.Ace)
            {
                return true;
            }

            return false;
        }
    }
}
