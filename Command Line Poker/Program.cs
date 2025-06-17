using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Command_Line_Poker;

// Command Line Poker!
// by Duncan Clark
// v1.0 Published: 6/17/2025

// About: A little programming project to continue to familiarize myself with C#, .Net, GitHub, and Visual Studio.
//        Learned a lot making this little thing, and it is by no means perfect, but I believe I accomplished
//        what I set out to do with this project, which was mainly to gain experience building on my previous blackjack program.
//        As a functional representation of five-card draw, there's much more that can be implemented, but there
//        are many better avenues to play it and I'm eager to move onto my next project. 

// TODO: - Add betting
//       - Add computer opponent for single play
//       - Implement logic for tied scores, kickers, etc.
//       - Add Texas Hold'em mode


class Poker
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Prints prints = new Prints();
        Console.WriteLine("\n");
        prints.startBanner();

        Thread.Sleep(2500);

        prints.screenClear();
        Console.WriteLine("\n");
        prints.welcomeBanner();

        Game game = new Game();
        Deck deck = new Deck();
        deck.Shuffle();

        List<Player> players = new List<Player>();

        game.InitializePlayers(players);

        Thread.Sleep(400);
        prints.wordRoll("\n - ", "Press any key to begin: ");
        Console.ReadKey(true);
        Thread.Sleep(600);
        prints.dotRoll("\n\n   ", "Starting game");
        Thread.Sleep(400);

        prints.screenClear();

        bool playing = true;

        while (playing)
        {
            game.Round(players, deck);
        }

    }
}

class Game
{
    public static int choosePlayerCount()
    {
        int count = 0;
        bool valid = false;

        Prints printer = new Prints();

        while (!valid)
        {
            printer.wordRoll(" - ", "Choose the number of players (1-4): ");
            string? input = Console.ReadLine();

            if (!Int32.TryParse(input, out count))
            {
                Console.WriteLine("   Invalid input.\n");
                continue;
            }
            
            valid = (count >= 1 && count <= 4) ? true : false;

            if (!valid)
            {
                Console.WriteLine("   Please enter a number between 1 and 4.\n");
            }
        }

        return count;
    }

    public void InitializePlayers(List<Player> players)
    {
        Prints print = new Prints();

        int count = choosePlayerCount();

        Thread.Sleep(100);
        print.lineRoll(0, "   ", "-", 1, 34);

        for (int i = 0; i < count; i++)
        {
            print.wordRoll("\n - ", "Enter name for player " + (i + 1) + ": ");
            string? name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine(" Invalid name. Please try again.\n");
                i--;
                continue;
            }
            if (name.Length > 16)
            {
                Console.WriteLine(" Name is too long. Please try again.\n");
                i--;
                continue;
            }

            Player initiate = new Player(name);
            players.Add(initiate);
        }

        if (players.Count > 1)
        {
            Random rand = new Random();
            players = players.OrderBy(x => rand.Next()).ToList();

            int charCount = 0;

            foreach (Player player in players)
            {
                foreach (char letter in player.Name)
                {
                    charCount++;
                }
            }

            print.lineRoll(0, "   ", "=", 1, 24 + charCount + (players.Count * 2));
            print.wordRoll("\n   ", "The turn order is: ");

            for (int i = 0; i < players.Count - 1; i++)
            {
                Console.Write($"{players[i].Name}, ");
            }

            Console.Write("then " + players[players.Count - 1].Name + ".\n");

            print.lineRoll(0, "   ", "=", 1, 24 + charCount + (players.Count * 2));
        }
        else if (players.Count == 1)
        {
            print.lineRoll(0, "   ", "-", 1, 34);
        }
    }
    public void DealCards(List<Player> players, Deck deck)
    {
        foreach (Player player in players)
        {
            for (int i = 0; i < 5; i++)
            {
                player.AddCard(deck.Deal());
            }
        }
    }

    public void DealCards(Dealer dealer, Deck deck)
    {
        for (int i = 0; i < 5; i++)
        {
            dealer.AddCard(deck.Deal());
        }
    }

    public void Round(List<Player> players, Deck deck)
    {
        Prints print = new Prints();
        print.screenClear();
        print.roundBanner();

        int roundCount = 0;

        Thread.Sleep(800);

        print.dotRoll("\n - ", "Shuffling deck");
        deck.Shuffle();
        
        print.dotRoll("\n\n - ", "Dealing cards");

        Thread.Sleep(600);

        DealCards(players, deck);

        foreach (Player player in players)
        {
            Turn(player, deck);
        }

        Results(players, ++roundCount);

        foreach (Player player in players)
        {
            player.Hand.Clear();
        }
    }

    public void Turn(Player player, Deck deck)
    {
        Prints print = new Prints();
        print.screenClear();
        print.tab(2);

        player.Hand = player.Hand.OrderByDescending(Card => Card.Rank).ToList();

        print.printPlayerStart(player);

        if (ReplaceCards(cardSelection(), player, deck))
        {
            player.Hand = player.Hand.OrderByDescending(Card => Card.Rank).ToList();
            print.printPlayerMulligan(player);
        }

        assignScore(player);
        print.printPlayerScore(player);

        Console.Write("\n\n - Press any key to end your turn: ");
        Console.ReadKey(true);
    }

    public void Results(List<Player> players, int roundCount)
    {
        Prints print = new Prints();
        print.screenClear();

        print.tab(1);
        print.resultsBanner(roundCount);
        print.tab(2);

        // Formating antics

        int len = 0, len2 = 0, len3 = 0;

        // Find max name and score string lengths
        foreach (Player player in players)
        {
            if (player.Name.Length > len && player.Name.Length < 20)
            {
                len = player.Name.Length;
            }

            if (Score[player.RoundScore].Length > len2)
            {
                len2 = Score[player.RoundScore].Length;
            }
        }

        len3 = len + len2 + 10;

        
        foreach (Player player in players)
        {
            // Pad name and score for alignment
            string namePadded = player.Name.PadRight(len);
            string scorePadded = Score[player.RoundScore].PadRight(len2);
            print.wordRoll(" | ", $"{namePadded} Scored: {scorePadded}");

            print.tab(1);
            Console.Write("   ");
            print.lineRoll("-", len3);
            print.tab(1);
        }

        Player winner = players.OrderByDescending(p => p.RoundScore).First();

        print.tab(1);
        Console.Write(" ");
        print.lineRoll("=", 34 + winner.Name.Length + Score[winner.RoundScore].Length);

        print.wordRoll("\n - ", $"The winner is {winner.Name} with a score of {Score[winner.RoundScore]}!");

        print.tab(1);
        Console.Write(" ");
        print.lineRoll("=", 34 + winner.Name.Length + Score[winner.RoundScore].Length);

        Console.Write("\n\n - Press any key to end round: ");
        Console.ReadKey(true);
        
    }

    public List<int> cardSelection()
    {
        bool valid = false;
        List<int> selection = new List<int>();

        while (!valid)
        {
            Console.Write("\n\n - Enter number(s) to replace card(s) // Press Enter To Skip: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return new List<int>();
            }

            input = input.ToLower().Replace(",", " ");
            string[] inputs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in inputs)
            {
                if (int.TryParse(word, out int number))
                {
                    if (number > 0 && number < 6)
                    {
                        selection.Add(number);
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        Console.WriteLine(" - Invalid input(s). Please enter numbers between 1 and 5.");
                        break;
                    }
                }
                else
                {
                    valid = false;
                    Console.WriteLine(" - Invalid input(s). Please enter numbers between 1 and 5.");
                    break;
                }
            }
        }

        return selection;
    }

    public bool ReplaceCards(List<int> cardSelection, Player player, Deck deck)
    {
        if (cardSelection.Count == 0)
        {
            return false;
        }

        foreach (int card in cardSelection)
        {
            player.Hand[card - 1] = deck.Deal();
        }

        return true;
    }

    public Dictionary<int, string> Score = new Dictionary<int, string>
    {
        { 10, "Royal Flush" },
        { 9, "Straight Flush" },
        { 8, "Four of a Kind" },
        { 7, "Full House" },
        { 6, "Flush" },
        { 5, "Straight" },
        { 4, "Three of a Kind" },
        { 3, "Two Pair" },
        { 2, "One Pair" },
        { 1, "High Card" }
    };

    public void assignScore(Player player)
    {
        ScoreEvaluation evaluation = new ScoreEvaluation();

        player.RoundScore = evaluation.getScore(player);
    }
    
}

public class Player
{
    public string Name { get; set; }
    public List<Card> Hand { get; set; }

    public int RoundScore { get; set; } = 0;
    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }
    public void AddCard(Card card)
    {
        Hand.Add(card);
    }
    public void WriteOutHand()
    {
        foreach (Card card in Hand)
        {
            Console.WriteLine(card.WriteOutCard());
        }
    }

    public void WriteHand(bool suit)
    {
        foreach (Card card in Hand)
        {
            card.WriteCard(suit);
            Console.Write(", ");
        }
    }

    public void PrintHand()
    {
        if (Hand == null || Hand.Count == 0) { return; }

        int lineCount = Hand[0].Art.Count;

        for (int i = 0; i < lineCount; i++)
        {
            foreach (var card in Hand)
            {
                Console.Write(card.Art[i]);
            }
            Console.WriteLine();
        }
    }
}

public class Dealer : Player
{
    public Dealer(string name) : base(name)
    {
    }
}


