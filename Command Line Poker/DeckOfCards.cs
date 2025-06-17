using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Line_Poker;

namespace Command_Line_Poker
{
    public enum Suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Ranks
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public class Card
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public List<string> Art = new List<string>
        {
            "  _____  ",
            " |     | ",
            " |     | ",
            " |     | ",
            " |_____| "
        };

        public Card(Suits suit, Ranks rank)
        {
            Suit = suit;
            Rank = rank;
            GenerateArt();
        }

        public string WriteOutCard()
        {
            return $"{Rank} of {Suit}";
        }

        public void WriteCard(bool suit)
        {
            Console.Write(this.rankSymbol());

            if (suit)
            {
                Console.Write(suitSymbol());
            }
        }

        public void PrintCard()
        {
            foreach (string line in Art)
            {
                Console.WriteLine(line);
            }
        }

        public string suitSymbol()
        {
            switch (Suit)
            {
                case Suits.Hearts:
                    // "♥"
                    return "\u2665";
                case Suits.Diamonds:
                    // "♦"
                    return "\u2666";
                case Suits.Clubs:
                    // "♣"
                    return "\u2663";
                case Suits.Spades:
                    // "♠"
                    return "\u2660";
                default:
                    return "?";
            }
        }

        public string rankSymbol()
        {
            switch (Rank)
            {
                case Ranks.Jack:
                    return "J";
                case Ranks.Queen:
                    return "Q";
                case Ranks.King:
                    return "K";
                case Ranks.Ace:
                    return "A";
                default:
                    return ((int)Rank).ToString();
            }

        }

        public void GenerateArt()
        {
            string rankSymbol = this.rankSymbol();
            string suitSymbol = this.suitSymbol();

            Art[0] = $"  _____  ";
            Art[1] = $" |{rankSymbol.PadRight(2)}   | ";
            Art[2] = $" |  {suitSymbol}  | ";
            Art[3] = $" |   {rankSymbol.PadLeft(2)}| ";
            Art[4] = $"  -----  ";
        }
    }
}

public class Deck
{
    public List<Card> deck = new List<Card>();
    public List<Card> exhaustPile = new List<Card>();
    public List<Card> discardPile = new List<Card>();

    public Deck()
    {
        foreach (Suits suit in Enum.GetValues(typeof(Suits)))
        {
            foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
            {
                deck.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        foreach (Card card in discardPile)
        {
            deck.Add(card);
        }

        Random rand = new Random();
        deck = deck.OrderBy(x => rand.Next()).ToList();
    }

    public Card Deal()
    {
        Card dealtCard = deck[0];
        discardPile.Add(deck[0]);
        deck.RemoveAt(0);

        return dealtCard;
    }

    public void WriteDeck()
    {
        foreach (Card card in deck)
        {
            Console.WriteLine(card.WriteOutCard());
        }
    }
}
