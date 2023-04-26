//

using System;
using static System.Console;
namespace TicTacToe
{
    /// <summary>
    /// Provides user with console output and prompts user input in order to simulate  a tic-tac-toe game.
    /// Has a start,run, and shut down cycle, allows user to play games with the users-chosen symbol until the user chooses otherwise.
    /// </summary>
    public static class Game
    {
        //Declaring Instances//
        static Player user = new Player(' ',0,0,0);
        static Player pc = new Player(' ',0,0,0);
        static Board board = new Board();
        static char flagTurn = ' ',replay;
        static bool currentlyPlaying,reusableBool;

        /// <summary>
        /// Provides user with menu/information while playing the game. 
        /// Outputs to console,Displays title, tic tac toe board, displays the users selected symbol and the systems symbol, Then displays a bottom border.
        /// </summary>
        private static void updateScreen() //Updates game screen 
        {
            Console.Clear();
            WriteLine("(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
            board.printBoard();
            WriteLine("\n\t\t\t\t\t User: {0} \t System: {1}", user.symbol, pc.symbol);
            WriteLine("\n(¯`·._.·(¯`·._.·(¯`·._.·(¯`·._.· Tic Tac Toe ·._.·´¯)·._.·´¯)·._.·´¯)·._.·´¯)");
        }

        /// <summary>
        /// Used to determine through user input if the user would like to make the first move.
        /// Also only accepts the key N or Y as input (representing Yes or No)
        /// </summary>
        private static void checkIfUserFirst()
        {
            bool correctSymbol = false;
            //  Loops to see if the user would like to go first and validates the input
            do
            {
                WriteLine("Would you like to go first? (Y/N) ");
                ConsoleKeyInfo keyRead = Console.ReadKey();
                //  Used to check if user would like to go first and if input is valid
                //  Checks if key pressed is Y, if so flagTurn is assigned to users symbol and correctSymbol = true
                if (keyRead.Key == ConsoleKey.Y)
                {
                    WriteLine("\n User Goes First!");
                    flagTurn = user.symbol;
                    correctSymbol = true;
                }
                //  Checks if key pressed is N, if so flagTurn is assigned to pcs symbol and correctSymbol = true
                else if (keyRead.Key == ConsoleKey.N)
                {
                    WriteLine("\n System Goes First!");
                    flagTurn = pc.symbol;
                    correctSymbol = true;
                }
                //  If any other key pressed, user is told to try again and correctSymbol remains false
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                }
             // Loops while the correctSymbol = false, while any key thats not N or Y is pressed
            } while (correctSymbol == false);
        }

        /// <summary>
        /// Used to determine whether user will play as 'X' or 'O' via user input.
        /// Only accepts X or O keys as user input (representing X and O)
        /// </summary>
        private static void userChooseSymbol()  //Gets users symbol X or O
        {
            //  Loops input for whether user would like to play as 'X' or 'O' and validates input
            do
            {
                WriteLine("Would you like to play as 'X' or 'O'' ?");
                ConsoleKeyInfo keyRead = Console.ReadKey();
                reusableBool = true;
                //  Used to determine if user would like to play as 'O' or 'X' and if user chose valid symbol
                //  Checks if key pressed is O key, if so user symbol is set to 'O'  and pc symbol to 'X'. reusableBool is also set to false
                if (keyRead.Key == ConsoleKey.O) //User chooses O
                {
                    WriteLine("\nUser has chosen 'O'"); 
                    user.symbol = ('O');
                    pc.symbol = ('X');
                    reusableBool = false;
                }
                //  Checks if key pressed is X key, if so user symbol is set to 'X'  and pc symbol to 'O'. reusableBool is also set to false
                else if (keyRead.Key == ConsoleKey.X)   //User chooses X
                {
                    WriteLine("\nUser has chosen 'X'");
                    user.symbol = ('X');
                    pc.symbol = ('O');
                    reusableBool = false;
                }
                //  If any other key pressed, user is told to try again and reusableBool remains true
                else
                {
                    WriteLine("\n Choice is unavailable! Please try again.");
                }
                //  Loops while reusableBool is true
            } while (reusableBool); //Repeat until X or O pressed
        }

        /// <summary>
        /// Used to set up the tic tac toe game, 
        /// board is reset and then displayed for user. If the game is not consecuative with another - then the users symbol is determined and assigned.
        /// In any case the user is asked if they would like to go first.
        /// </summary>
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

        /// <summary>
        /// Used to display options to prompt the user to take a turn during the game. Takes user input via either number keys 1-9 or numpad 1-9 or 0 for exiting.
        /// Will only accept a coordinate that is displayed as open on the console.
        /// </summary>
        private static void gameMenu() //game menu
        {

            bool correctOption = false;
            int keyEntered;
            //  Loops for users input on which coordinate they choose or exiting the game
            do
            {
                WriteLine("-----------------------------------");

                WriteLine("Enter '0' to exit game");

                WriteLine("Enter Coordinate to place token (1-9)");

                WriteLine("-----------------------------------");
                ConsoleKeyInfo keyRead = Console.ReadKey(); 

                keyEntered = convertAscii(Convert.ToInt32(keyRead.Key));
                //  Used to check if user wishes to exit or if their number is a valid coordinate to choose
                //  Checks if keyEntered equals 0, if so then currentlyPlaying is set to false and correctOption is set to true - Exits game
                if (keyEntered == 0)
                {
                    currentlyPlaying = false;
                    correctOption = true;
                }
                //  Checks if keyEntered is greater than 0, if so correctOption is set to return value of function to check if the move was valid
                else if (keyEntered > 0)
                {
                    correctOption = board.checkIfCellAvailable(keyEntered - 1, flagTurn);
                }
                //  Continues while the correctOption is false and currentlyPlaying is true
            } while (correctOption == false && currentlyPlaying == true);
        }


        /// <summary>
        /// Converts the value from the unicode value of the key to the corresponding integer.
        /// </summary>
        /// <param name="value"> Represents the unicode value of the key pressed by the user</param>
        /// <returns> A bit-32 integer, converted from unicode to its intended value.
        /// (keyboard numbers 0 to 9 = 48 to 57) (numpad numbers 0 to 9 = 96 to 105) </returns>
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

        /// <summary>
        /// Used while the game is in progress, Checks for win conditions and flags for when it is the users/systems turn to choose a coordinate.
        /// When an end condition is met, the board displayed is updated one last time and the statistics are added to the appropriate variables
        /// </summary>
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
                    pc.wins++;
                    user.losses++;
                } 
            if(board.checkWinCondition(user.symbol) == true)
                {
                    user.wins++;
                    pc.losses++;
                }
            else if(board.checkTieCondition() == true)
            {
                pc.ties++;
                user.ties++;  
            }
         
        }

        /// <summary>
        /// Used when the end condition is met in the game. Stops the timer and then stores the data in gameTimeStats. 
        /// Uses the checkIfPlay again to see if the user wants to play another round of Tic-Tac-Toe.
        /// </summary>
        private static void ShutDown()
        {
            gameTimeStats.stopTime();
            gameTimeStats.setGameWinLoss(user.wins, user.losses, user.ties);
            if (currentlyPlaying == true)
            {
                currentlyPlaying = checkIfPlayAgain();
            }

        }
        
        /// <summary>
        /// Used to determine whether the user would like to play another round of Tic-Tac-Toe. 
        /// Prompts user to if they would like to play again and to decide yes or no, only accepts Y or N key (representing Yes or No)
        /// </summary>
        /// <returns>Bool, representing whether the user wants to keep playing (true for yes, false for no) </returns>
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

        /// <summary>
        /// Used to initialize game and run all cycles of the game: Start Up,Run and Shut Down.
        /// Loops the cycles as rounds of Tic-Tac-Toe for as long as the user wishes to play rounds of Tic-Tac-Toe.
        /// </summary>
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


