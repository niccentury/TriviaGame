using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TriviaGame
{
    /*Still do the randomizer, max score to win and change text for correct and wrong answer
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */


    class Game
    {
        private Random random = new Random();
        public Answers a;
        public Game(Answers a)
        {
            this.a = a;
        }

        int mapIterator = 0;
        int sapIterator = 0;
        int hapIterator = 0;

        int[] playerScores = new int[] { 0, 0, 0, 0 };
        int maxScore = 3;
        int currentPlayer = 0;
        int[] iteratorArray;
        bool wonGame = false;

        public bool[] playerArray = new bool[4];

        //Control the state of the game
        public void GameFunc()
        {
            iteratorArray = new int[] { mapIterator, sapIterator, hapIterator };
            
            Console.WriteLine("Welcome to my Trivia Game!!!\n\n Press ENTER to see rules...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The Rules of the Game are very simple.\n\n");
            Thread.Sleep(2000);
            Console.WriteLine($"▲ Must have 4 players to play the game.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ If a player answers a question correctly, the turn DOES NOT remain with that player.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ A player can forfiet their turn by pressing enter.\n");
            Thread.Sleep(1000);
            Console.WriteLine("▲ Lastly, which ever player reached the score limit first shall win.\n");
            Thread.Sleep(1000);
            Console.WriteLine("Press ENTER to start Game!!");
            Console.ReadKey();
            Console.Clear();

            CategoryPicker();
        }

        //Control the picking of Category and handles the user input
        public void CategoryPicker()
        {
            if (wonGame == true)
                GameFunc();

            Console.WriteLine($"PLAYER {currentPlayer + 1}: It's your turn!!!\n\n");
            Console.WriteLine("-------------------------Pick a Category---------------------------");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|1.)Computer Science      2.)History         3.)Science           |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\n\nUsing the number pad, press the corresponding number for the category you wish to select");
            
            int keyInput = Console.ReadKey(true).KeyChar - '0';
            Console.Clear();
            if (keyInput < 1 || keyInput > 3)
            {
                Console.Clear();
                CategoryPicker();
            }

            QuestionHandler(keyInput - 1);
        }

        
        //Populates questions from the Dictionaries
        public void QuestionHandler(int x)
        {

            int currentIterator = iteratorArray[x];
            string currentKey = a.categories[x].Keys.ElementAt(currentIterator);
            Console.WriteLine($"{currentKey}\n\n\n\n");
            int tracker = 1;

            for (int i = 0; i < a.allAnswers[x][currentIterator].Count; i++)
            {
                int k = random.Next(0, i);
                string value = a.allAnswers[x][currentIterator][k];
                a.allAnswers[x][currentIterator][k] = a.allAnswers[x][currentIterator][i];
                a.allAnswers[x][currentIterator][i] = value;
            }

            foreach (string answer in a.allAnswers[x][currentIterator])
            {
                Console.WriteLine($" {tracker}) {answer}\n\n");
                tracker++;
            }

            int playerAnswer = Console.ReadKey(true).KeyChar - '0';

            if(playerAnswer == -35)
            {
                Console.WriteLine("You passed your turn");
                iteratorArray[x]++;
                Thread.Sleep(2000);
                Console.Clear();
                PlayerHandler(false);
                CategoryPicker();
            }
            else if (a.allAnswers[x][currentIterator][playerAnswer - 1] == a.categories[x][currentKey])
            {
                Console.WriteLine("Correct!");
                iteratorArray[x]++;
                Thread.Sleep(2000);
                Console.Clear();
                PlayerHandler(true);
                CategoryPicker();
            }
            else
            {
                Console.WriteLine("Incorrect Answer");
                iteratorArray[x]++;
                Thread.Sleep(2000);
                Console.Clear();
                PlayerHandler(false);
                CategoryPicker();
            }

           



        }
        public void PlayerHandler(bool isCorrect)
        {
            if (isCorrect)
            {
                if (currentPlayer < 3)
                {
                    playerScores[currentPlayer]++;

                    foreach (int score in playerScores)
                    {
                        if (score == maxScore)
                        {
                            Console.Clear();
                            wonGame = true;
                            Console.WriteLine($"Player {currentPlayer + 1} is the WINNER!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Console.WriteLine("Would you like to play agian?\n\n" +
                                "type YES of NO");
                            string playAgain = Console.ReadLine().ToUpper();
                            if (playAgain == "NO")
                            {
                                wonGame = false;
                                System.Environment.Exit(1);
                            }
                            else 
                                wonGame = false;
                                Console.Clear();
                            return;
                        }
                    }
                    currentPlayer++;
                    
                }
                else
                {
                    playerScores[currentPlayer]++;

                    foreach (int score in playerScores)
                    {
                        if (score == maxScore)
                        {
                            Console.Clear();
                            wonGame = true;
                            Console.WriteLine($"Player {currentPlayer + 1} is the WINNER!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            return;
                        }
                    }

                    currentPlayer = 0;
                    CategoryPicker();
                }
            }
            else
            {
                if (currentPlayer < 3)
                {
                    currentPlayer++;
                    
                }
                else
                {
                    currentPlayer = 0;
                    CategoryPicker();
                }
            }
        }
    }
}
