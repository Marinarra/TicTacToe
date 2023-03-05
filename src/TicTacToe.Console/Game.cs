//

using System;
using static System.Console;
namespace TicTacToe
{
    public static class Game
    {
        //Declaring Instances//
        static Player user = new Player();
        static Player pc = new Player();
        static Board board = new Board();
        static char flagTurn = ' ';


        private static void updateScreen() //Updates game screen 
        {
            Console.Clear();
            WriteLine("(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
            board.printBoard();
            WriteLine("\n\t\t\t\t\t User: {0} \t System: {1}", user.getSymbol(), pc.getSymbol());
            WriteLine("\n(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
        }

        private static void checkIfUserFirst()
        {
            bool correctSymbol;
            do
            {
                WriteLine("Would you like to go first? (Y/N) ");
                ConsoleKeyInfo keyRead = Console.ReadKey();

                if (keyRead.Key == ConsoleKey.Y)
                {
                    WriteLine("\n User Goes First!");
                    flagTurn = user.getSymbol();
                    correctSymbol = true;
                }
                else if (keyRead.Key == ConsoleKey.N)
                {
                    WriteLine("\n System Goes First!");
                    flagTurn = pc.getSymbol();
                    correctSymbol = true;
                }
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                    correctSymbol = false;
                }
            } while (true);
        }

        private static void userChooseSymbol()  //Gets users symbol X or O
        {
            do
            {
                WriteLine("Would you like to play as 'X' or 'O'' ?");
                ConsoleKeyInfo keyRead = Console.ReadKey();

                if (keyRead.Key == ConsoleKey.O) //User chooses O
                {
                    WriteLine("\nUser has chosen 'O'"); 
                    user.setPlayerSymbol('O');
                    pc.setPlayerSymbol('X');
                    break;
                }
                else if (keyRead.Key == ConsoleKey.X)   //User chooses X
                {
                    WriteLine("\nUser has chosen 'X'");
                    user.setPlayerSymbol('X');
                    pc.setPlayerSymbol('O');
                    break;
                }
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                }
            } while (true); //Repeat until X or O pressed
        }

        private static void startUpCycle() //start up cycle
        {
            updateScreen();
            pc.setPlayerSymbol(' ');
            user.setPlayerSymbol(' ');
            updateScreen();
            userChooseSymbol();
            checkIfUserFirst();
        }
        private static void gameMenu() //game menu
        {

            bool correctOption;
            int keyEntered;
            do
            {
                WriteLine("-----------------------------------");

                WriteLine("Enter '0' to exit game");

                WriteLine("Enter Coordinate to place token (1-9)");

                WriteLine("-----------------------------------");

                keyEntered = Convert.ToInt32(ReadLine());
                if (keyEntered == 0)
                {
                    Environment.Exit(0);
                }
                correctOption = board.checkIfCellAvailable(keyEntered - 1, flagTurn);
            } while (!correctOption);
        }

        private static void RunCycle()
        {
            do
            {
                if (flagTurn == pc.getSymbol())
                {
                    board.systemChoose(flagTurn);
                    flagTurn = user.getSymbol();
                    updateScreen();
                }

                if (flagTurn == user.getSymbol())
                {
                    updateScreen();
                    gameMenu();
                    flagTurn = pc.getSymbol();
                }

            } while (!(board.checkWinCondition(pc.getSymbol()) == true || board.checkWinCondition(user.getSymbol()) == true|| board.checkTieCondition() == true));

            updateScreen();

            if (board.checkWinCondition(pc.getSymbol()) == true)
            {
                    pc.addPlayerWin();
                    user.addPlayerLoss();
                } else if(board.checkWinCondition(user.getSymbol()) == true)
                {
                    user.addPlayerWin();
                    pc.addPlayerLoss();
                }
            
            else
            {
                pc.addTie();
                user.addTie();  
            }
         
        }
        private static void printGameStats()
        {
            WriteLine("-----------------------------------");
            WriteLine("\tUser Wins\t User Losses ");
            WriteLine("\t{0}\t\t{1}", user.getPlayerWins(), user.getPlayerLosses());
            WriteLine("-----------------------------------");
            WriteLine("\tSystem Wins\t System Losses ");
            WriteLine("\t{0}\t\t{1}", pc.getPlayerWins(), pc.getPlayerWins());
            WriteLine("Times Tied = {0}", user.getTies());


        }

        private static bool checkIfPlayAgain()
        {
            
            WriteLine("-----------------------------------");
            WriteLine("\t\t Would you like to play again? Y/N \n");
            WriteLine("-----------------------------------\n");
            ConsoleKeyInfo keyRead = Console.ReadKey();
            do
            {
                if (keyRead.Key == ConsoleKey.Y)
                {
                    board.resetBoard();
                    return true;
                }
                else if (keyRead.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    WriteLine("Choice unavailable, please try again Y/N \n");
                    keyRead = Console.ReadKey();
                }
            } while (true);

        }

        public static void startGame()
        {
            
            do
            {
                startUpCycle(); //User selects to go first or not & user selects symbol
                RunCycle();     // User Coordinate input & RNG System choice
            } while (checkIfPlayAgain() == true);
            printGameStats();

        }

    }
}


