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
        static char flagTurn = ' ',replay;
        static bool currentlyPlaying,reusableBool;

        private static void updateScreen() //Updates game screen 
        {
            Console.Clear();
            WriteLine("(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
            board.printBoard();
            WriteLine("\n\t\t\t\t\t User: {0} \t System: {1}", user.symbol, pc.symbol);
            WriteLine("\n(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
        }

        private static void checkIfUserFirst()
        {
            bool correctSymbol = false;
            do
            {
                WriteLine("Would you like to go first? (Y/N) ");
                ConsoleKeyInfo keyRead = Console.ReadKey();

                if (keyRead.Key == ConsoleKey.Y)
                {
                    WriteLine("\n User Goes First!");
                    flagTurn = user.symbol;
                    correctSymbol = true;
                }
                else if (keyRead.Key == ConsoleKey.N)
                {
                    WriteLine("\n System Goes First!");
                    flagTurn = pc.symbol;
                    correctSymbol = true;
                }
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                }
            } while (correctSymbol == false);
        }

        private static void userChooseSymbol()  //Gets users symbol X or O
        {
            do
            {
                WriteLine("Would you like to play as 'X' or 'O'' ?");
                ConsoleKeyInfo keyRead = Console.ReadKey();
                reusableBool = true;
                if (keyRead.Key == ConsoleKey.O) //User chooses O
                {
                    WriteLine("\nUser has chosen 'O'"); 
                    user.symbol = ('O');
                    pc.symbol = ('X');
                    reusableBool = false;
                }
                else if (keyRead.Key == ConsoleKey.X)   //User chooses X
                {
                    WriteLine("\nUser has chosen 'X'");
                    user.symbol = ('X');
                    pc.symbol = ('O');
                    reusableBool = false;
                }
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                }
            } while (reusableBool); //Repeat until X or O pressed
        }

        private static void startUpCycle() //start up cycle
        {
            board.resetBoard();
            updateScreen();
            if (replay == 'n')
            {
                pc.symbol = (' ');
                user.symbol = (' ');
                updateScreen();
                userChooseSymbol();
            }
            checkIfUserFirst();
        }
        private static void gameMenu() //game menu
        {

            bool correctOption = false;
            int keyEntered;

            do
            {
                WriteLine("-----------------------------------");

                WriteLine("Enter '0' to exit game");

                WriteLine("Enter Coordinate to place token (1-9)");

                WriteLine("-----------------------------------");
                ConsoleKeyInfo keyRead = Console.ReadKey(); 

                keyEntered = convertAscii(Convert.ToInt32(keyRead.Key));
                if (keyEntered == 0)
                {
                    currentlyPlaying = false;
                    correctOption = true;
                }
                else if (keyEntered > 0)
                {
                    correctOption = board.checkIfCellAvailable(keyEntered - 1, flagTurn);
                }
            } while (correctOption == false && currentlyPlaying == true);
        }
        
        private static int convertAscii(int value)
        {
            if(value <= 57 && value >= 48)
            {
                value -= 48;
            } 
            else if(value >= 96 && value <= 105){
                value -= 96;
            }
            return value;
        }

        private static void RunCycle()
        {
            gameTimeStats.startTimer();
            bool isGameWon = false; //  Game won/tied = true, game not won/tied = false
            do
            {
                isGameWon = (board.checkWinCondition(pc.symbol) || board.checkWinCondition(user.symbol) || board.checkTieCondition()); // checks if pc win OR user win OR tie
                if (flagTurn == pc.symbol && isGameWon == false)  // system turn
                {
                    board.systemChoose(flagTurn);
                    flagTurn = user.symbol;
                    updateScreen();
                }

                isGameWon = (board.checkWinCondition(pc.symbol) || board.checkWinCondition(user.symbol) || board.checkTieCondition()); // checks if pc win OR user win OR tie

                if (flagTurn == user.symbol  && isGameWon == false)  // user turn
                {
                    updateScreen();
                    gameMenu();
                    flagTurn = pc.symbol;
                }

            } while (isGameWon == false && currentlyPlaying == true); 

            updateScreen();

            if (board.checkWinCondition(pc.symbol) == true)
            {
                    pc.addPlayerWin();
                    user.addPlayerLoss();
                } 
            if(board.checkWinCondition(user.symbol) == true)
                {
                    user.addPlayerWin();
                    pc.addPlayerLoss();
                }
            else if(board.checkTieCondition() == true)
            {
                pc.addTie();
                user.addTie();  
            }
         
        }

        private static void ShutDown()
        {
            gameTimeStats.stopTime();
            gameTimeStats.setGameWinLoss(user.getPlayerWins(), user.getPlayerLosses(), user.getTies());
            if (currentlyPlaying == true)
            {
                currentlyPlaying = checkIfPlayAgain();
            }

        }
        

        private static bool checkIfPlayAgain()
        {
            
            WriteLine("-----------------------------------");
            WriteLine("\t\t Would you like to play again? Y/N \n");
            WriteLine("-----------------------------------\n");
            ConsoleKeyInfo keyRead = Console.ReadKey();
            bool inputValid = true;
            do
            {
                if (keyRead.Key == ConsoleKey.Y)
                {
                    reusableBool = true;
                    replay = 'y';
                }
                else if (keyRead.Key == ConsoleKey.N)
                {
                    reusableBool = false;
                }
                else
                {
                    WriteLine("Choice unavailable, please try again Y/N \n");
                    keyRead = Console.ReadKey();
                    inputValid = false;
                }
            } while (!(inputValid));

            return reusableBool;

        }


        public static void startGame()
        {
            currentlyPlaying = true;
            replay = 'n';
            do
            {
                
                startUpCycle(); //User selects to go first or not & user selects symbol
                RunCycle();     // User Coordinate input & RNG System choice
                ShutDown();     //Display Statistics of game and game time played and the average time
            } while ( currentlyPlaying == true);
            

        }

    }
}


