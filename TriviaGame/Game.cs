using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TriviaGame
{
    class Game
    {
        Answers a = new Answers();
        public bool player1Turn = true;
        public bool player2Turn = false;
        public bool player3Turn = false;
        public bool player4Turn = false;

        public bool[] playerArray = new bool[4];
       
        
        

        public List<string> correctAnswers = new List<string>();

        public void GameFunc()
        {
           
            bool gameStart = false;
            Console.WriteLine("Welcome to my Trivia Game!!!\n\n Press ENTER to see rules...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The Rules of the Game are very simple.\n\n");
            Thread.Sleep(2000);
            Console.WriteLine($"▲ Must have 4 players to play the game.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ If a player answers a question correctly, the turn remains with that player.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ A player can forfiet their turn by pressing enter.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ Lastly, which ever player reached the score limit first shall win.\n");
            Thread.Sleep(1000);
            Console.WriteLine("Press ENTER to start Game!!");
            Console.ReadKey();
            Console.Clear();

            playerArray = new bool[] { player1Turn, player2Turn, player3Turn, player4Turn};

            gameStart = true;

            CategoryPicker();

        }

        
        public void CategoryPicker()
        {
            Console.WriteLine("-------------------------Pick a Category---------------------------");
            Console.WriteLine("|                                                                 | ");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|1.)Computer Science      2.)History         3.)Science           |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\n\nUsing the number pad, press the corresponding number for the category you wish to select");
            int keyInput = Console.ReadKey(true).KeyChar - '0';

            if (keyInput < 1 || keyInput > 3)
            {
                Console.Clear();
                CategoryPicker();
            }

            QuestionHandler(keyInput);
        }

        

        public void QuestionHandler(int x)
        {
            if (player1Turn == true) {
                if (x == 1)
                {
                    for (int i = 0; i < a.map.Count; i++)
                    {
                        Console.WriteLine(a.map.Keys.ElementAt(i));  
                    }
                }
                else if (x == 2)
                {
                    Console.WriteLine("Chicken");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Steak");
                }
                player1Turn = false;
                player1Turn = true;
            }

            if (player2Turn == true)
            {
                if (x == 1)
                {
                    Console.WriteLine("Turkey");
                }
                else if (x == 2)
                {
                    Console.WriteLine("Chicken");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Steak");
                }
                player2Turn = false;
                player3Turn = true;
            }

            if (player3Turn == true)
            {
                if (x == 1)
                {
                    Console.WriteLine("Turkey");
                }
                else if (x == 2)
                {
                    Console.WriteLine("Chicken");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Steak");
                }
                player3Turn = false;
                player4Turn = true;
            }

            if (player4Turn == true)
            {
                if (x == 1)
                {
                    Console.WriteLine("Turkey");
                }
                else if (x == 2)
                {
                    Console.WriteLine("Chicken");
                }
                else if (x == 3)
                {
                    Console.WriteLine("");
                }
                player4Turn = false;
                player1Turn = true;
            }
        }
        public void PlayerHandler()
        {
            
        }
    }
}
