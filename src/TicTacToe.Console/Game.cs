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
        static bool currentlyPlaying,reusableBool;

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
            bool correctSymbol = false;
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
                }
            } while (correctSymbol == false);
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
            board.resetBoard();
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
                ConsoleKeyInfo keyRead = Console.ReadKey(); 

                keyEntered = convertAscii(Convert.ToInt32(keyRead.Key));
                if (keyEntered == 0)
                {
                    currentlyPlaying = false;
                    break;
                }
                correctOption = board.checkIfCellAvailable(keyEntered - 1, flagTurn);
            } while (correctOption == false);
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
            reusableBool = false; //  Game won/tied = true, game not won/tied = false
            do
            {
                if (flagTurn == pc.getSymbol() && reusableBool != true)  // system turn
                {
                    board.systemChoose(flagTurn);
                    flagTurn = user.getSymbol();
                    updateScreen();
                }
                reusableBool = board.checkWinCondition(pc.getSymbol()) | board.checkWinCondition(user.getSymbol()) | board.checkTieCondition(); // checks if pc win OR user win OR tie

                if (flagTurn == user.getSymbol()  && reusableBool != true)  // user turn
                {
                    updateScreen();
                    gameMenu();
                    flagTurn = pc.getSymbol();
                }

            } while (reusableBool != true && currentlyPlaying == true); 

            updateScreen();

            if (board.checkWinCondition(pc.getSymbol()) == true)
            {
                    pc.addPlayerWin();
                    user.addPlayerLoss();
                } 
            if(board.checkWinCondition(user.getSymbol()) == true)
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
            printGameStats();
            if (currentlyPlaying == true)
            {
                currentlyPlaying = checkIfPlayAgain();
            }

        }
        private static void printGameStats()
        {
            WriteLine("-----------------------------------");
            WriteLine("\tUser Wins\t User Losses ");
            WriteLine("\t{0}\t\t{1}", user.getPlayerWins(), user.getPlayerLosses());
            WriteLine("-----------------------------------");
            WriteLine("\tSystem Wins\t System Losses ");
            WriteLine("\t{0}\t\t{1}", pc.getPlayerWins(), pc.getPlayerLosses());
            WriteLine("Times Tied = {0}", user.getTies());
            WriteLine("-----------------------------------");
            WriteLine("\t\t Time spent in game: {0:00:00}" +
                    "\n\t\t Time spent on average: {1:00:00} " +
                    "\n\t\t Total time spent across all games: {2:00:00} ",gameTimeStats.getGameTime(), gameTimeStats.getAvgGameTime(),gameTimeStats.getTotalGameTime());
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
            do
            {
                
                startUpCycle(); //User selects to go first or not & user selects symbol
                RunCycle();     // User Coordinate input & RNG System choice
                ShutDown();     //Display Statistics of game and game time played and the average time
            } while ( currentlyPlaying == true);
            

        }

    }
}


