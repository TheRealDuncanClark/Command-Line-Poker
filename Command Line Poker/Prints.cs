using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Command_Line_Poker
{
    internal class Prints()
    {
        public void startBanner()
        {
            if (Console.WindowWidth > 120)
            {
                largeStartBanner();
            }
            else
            {
                smallStartBanner();
            }
        }
        public void largeStartBanner()
        {
            string[] banner = new[]
            {
           @"   ______                                                                   __        __        __                       ",
           @"  /      \                                                                 /  |      /  |      /  |                      ",
           @" /$$$$$$  |  ______   _____  ____   _____  ____    ______   _______    ____$$ |      $$ |      $$/  _______    ______    ",
           @"  $$ |  $$/  /      \ /     \/    \ /     \/    \  /      \ /       \  /    $$ |      $$ |      /  |/       \  /      \  ",
           @"  $$ |      /$$$$$$  |$$$$$$ $$$$  |$$$$$$ $$$$  | $$$$$$  |$$$$$$$  |/$$$$$$$ |      $$ |      $$ |$$$$$$$  |/$$$$$$  | ",
           @"  $$ |   __ $$ |  $$ |$$ | $$ | $$ |$$ | $$ | $$ | /    $$ |$$ |  $$ |$$ |  $$ |      $$ |      $$ |$$ |  $$ |$$    $$ | ",
           @"  $$ \__/  |$$ \__$$ |$$ | $$ | $$ |$$ | $$ | $$ |/$$$$$$$ |$$ |  $$ |$$ \__$$ |      $$ |_____ $$ |$$ |  $$ |$$$$$$$$/  ",
           @"  $$    $$/ $$    $$/ $$ | $$ | $$ |$$ | $$ | $$ |$$    $$ |$$ |  $$ |$$    $$ |      $$       |$$ |$$ |  $$ |$$       | ",
           @"   $$$$$$/   $$$$$$/  $$/  $$/  $$/ $$/  $$/  $$/  $$$$$$$/ $$/   $$/  $$$$$$$/       $$$$$$$$/ $$/ $$/   $$/  $$$$$$$/  ",
           @"                                                                                                                         ",
           @"                                                                                                                         ",
           @" ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::",
           @" :::'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:'#######:",
           @" :::........:........:........:........:........:........:........:........:........:........:........:........:........:",
           @"                                                                                                                         ",
           @"                                                                                                                         ",
           @"                                 _______             __                            __                                    ",
           @"                                /       \           /  |                          /  |                                   ",
           @"                                $$$$$$$  |  ______  $$ |   __   ______    ______  $$ |                                   ",
           @"                                $$ |__$$ | /      \ $$ |  /  | /      \  /      \ $$ |                                   ",
           @"                                $$    $$/ /$$$$$$  |$$ |_/$$/ /$$$$$$  |/$$$$$$  |$$ |                                   ",
           @"                                $$$$$$$/  $$ |  $$ |$$   $$<  $$    $$ |$$ |  $$/ $$/                                    ",
           @"                                $$ |      $$ \__$$ |$$$$$$  \ $$$$$$$$/ $$ |       __                                    ",
           @"                                $$ |      $$    $$/ $$ | $$  |$$       |$$ |      /  |                                   ",
           @"                                $$/        $$$$$$/  $$/   $$/  $$$$$$$/ $$/       $$/                                    ",
        };

            Console.WriteLine(string.Join("\n", banner));
        }

        public void smallStartBanner()
        {
            string[] banner =
            {
             "██████╗  ██████╗ ██╗  ██╗███████╗██████╗  ██╗",
             "██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝██╔══██╗ ██║",
             "██████╔╝██║   ██║█████╔╝ █████╗  ██████╔╝ ██║",
             "██╔═══╝ ██║   ██║██╔═██╗ ██╔══╝  ██╔══██╗ ╚═╝",
             "██║     ╚██████╔╝██║  ██╗███████╗██║  ██║ ██╗",
             "╚═╝      ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═╝"
        };

            for (int i = 0; i < banner.Length; i++)
            {
                for (int j = 0; j < (Console.WindowWidth / 4) + 6; j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(banner[i]);
                Thread.Sleep(100);
            }


        }

        public void welcomeBanner()
        {
            Console.WriteLine($"               ==========================================");
            Console.WriteLine($"                            Welcome to Poker!            ");
            Console.WriteLine($"               ==========================================");
            Console.WriteLine("\n");
        }

        public void roundBanner()
        {
            Console.WriteLine("\n");

            string[] banner = new[]
            {
                   @".------..------..------..------..------.     .------..------..------..------..------.",
                   @"|R.--. ||O.--. ||U.--. ||N.--. ||D.--. |     |S.--. ||T.--. ||A.--. ||R.--. ||T.--. |",
                   @"| :/\: || :/\: || :/\: || :/\: || :/\: |     | :/\: || :/\: || :/\: || :/\: || :/\: |",
                   @"| :\/: || :\/: || :\/: || :\/: || :\/: |     | :\/: || :\/: || :\/: || :\/: || :\/: |",
                   @"| '--'R|| '--'O|| '--'U|| '--'N|| '--'D|     | '--'S|| '--'T|| '--'A|| '--'R|| '--'T|",
                   @"`------'`------'`------'`------'`------'     `------'`------'`------'`------'`------'",
                   @"                                                                                     ",
                   @"   =====================================     ===================================== "
            };

            for (int i = 0; i < banner.Length; i++)
            {
                for (int j = 0; j < (Console.WindowWidth / 6) - 4; j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(banner[i]);
                Thread.Sleep(100);
            }
        }

        public void smallPlayerBanner(string name)
        {
            string phrase = "=== " + name + "'s Turn! ===";

            int spacing = (Console.WindowWidth / 2) - (phrase.Length / 2);

            for (int i = 0; i < spacing; i++)
            {
                Console.Write(" ");
            }

            wordRoll("===", phrase);
        }

        // TODO: FIX
        public int playerBannerSize(string name)
        {
            // The length of "'s turn" (without the space);
            int affix = 6;

            // The length of each letter's card;
            int cardLength = 8;

            return cardLength * (name.Length + affix + 1);
        }

        // TODO: FIX
        public void playerBanner(string name)
        {
            Console.WriteLine("\n");

            List<string[]> banner = new List<string[]>();

            // Generating Player's Name

            foreach (char letter in name)
            {
                string let = letter.ToString().ToUpper();

                string[] nameCard = new string[6];

                nameCard[0] = $".------.";
                nameCard[1] = $"|{let}.--. |";
                nameCard[2] = @"| :/\: |";
                nameCard[3] = @"| :\/: |";
                nameCard[4] = $"| '--'{let}|";
                nameCard[5] = $"`------'";

                banner.Add(nameCard);
            }

            // Generating Affix

            string affix = "'S      TURN";

            foreach (char letter in affix)
            {

                if (letter == ' ')
                {
                    string[] space = new[]
                    {
                        @" ",
                        @" ",
                        @" ",
                        @" ",
                        @" ",
                        @" "
                    };

                    banner.Add(space);
                }
                else
                {
                    string let = letter.ToString().ToUpper();

                    string[] nameCard = new string[8];

                    nameCard[0] = $".------.";
                    nameCard[1] = $"|{let}.--. |";
                    nameCard[2] = @"| :/\: |";
                    nameCard[3] = @"| :\/: |";
                    nameCard[4] = $"| '--'{let}|";
                    nameCard[5] = $"`------'";
                    nameCard[6] = $"        ";
                    nameCard[7] = $"========";

                    banner.Add(nameCard);
                }
            }

            Prints print = new Prints();
            int spacing = Console.WindowWidth - print.playerBannerSize(name) / 2;
            
            int lineCount = banner[0].Length;

            for (int i = 0; i < lineCount; i++)
            {
                for (int j = 0; j < spacing; j++)
                {
                    Console.Write(" ");
                }

                foreach (var card in banner)
                {
                    Console.Write(card[i]);
                }
            }
        }

        public void resultsBanner(int roundCount)
        {
            string phrase = "====== Round " + roundCount + " Results ======";
            string line = "-----------------------------";

            int spacing = (Console.WindowWidth / 2) - (phrase.Length / 2);

            for (int i = 0; i < spacing; i++)
            {
                Console.Write(" ");
            }

            wordRoll("", phrase);

            tab(1);

            for (int i = 0; i < spacing; i++)
            {
                Console.Write(" ");
            }

            wordRoll("", line);
        }

        public void screenClear()
        {
            Console.Clear();
        }

        public void lineRoll(int lineSpacing, string prefix, string line, int bufferDivision, int length)
        {
            for (int i = 0; i < lineSpacing; i++)
            {
                Console.Write("\n");
            }

            for (int i = 0; i < (Console.WindowWidth / bufferDivision); i++)
            {
                Console.Write(" ");
            }

            Console.Write(prefix);

            for (int i = 0; i < length; i++)
            {
                Console.Write(line);
                Thread.Sleep(1);
            }

            Console.Write("\n");
        }

        public void lineRoll(string line, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(line);
                Thread.Sleep(1);
            }
        }

        public void wordRoll(string prefix, string word)
        {
            Console.Write(prefix);

            foreach (char letter in word)
            {
                Console.Write(letter);
                Thread.Sleep(3);
            }
        }

        public void dotRoll(string text)
        {
            Console.Write(text);

            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }

        public void dotRoll(string prefix, string text)
        {
            Console.Write(prefix + text);

            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }

        public void tab(int length)
        {
            for (int i = 0; i < length; i++) { Console.WriteLine(" "); }
        }

        public void printPlayerStart(Player player)
        {
                    /*
                    if (Console.WindowWidth > playerBannerSize(player.Name))
                    {
                        playerBanner(player.Name);
                    }
                    else
                    {
                        smallPlayerBanner(player.Name);
                    }*/

            smallPlayerBanner(player.Name);

            Thread.Sleep(800);

            tab(Console.WindowHeight - 8);

            wordRoll(" | ", $"Your hand: ");
            player.WriteHand(false);

            int handLength = 8 * 5 + 2;

            string bar = new string('-', 14);
            string bar2 = new string('=', handLength);

            wordRoll(" ", bar);

            tab(2);

            player.PrintHand();

            Console.WriteLine($"   [1]      [2]      [3]      [4]      [5]\n");

            wordRoll(" ", bar2);
        }

        public void printPlayerMulligan(Player player)
        {

            tab(2);

            wordRoll(" | ", $"Mulligan: ");
            player.WriteHand(false);

            int handLength = 8 * 5 + 2;

            string bar = new string('-', 14);
            string bar2 = new string('=', handLength);

            wordRoll(" ", bar);

            tab(2);

            player.PrintHand();

            tab(2);

            wordRoll(" ", bar2);
        }

        public void printPlayerScore(Player player)
        {
            Game game = new Game();

            tab(2);
            wordRoll(" | ", $"{player.Name} Scored: {game.Score[player.RoundScore]}");
            tab(1);
        }
    }
}
