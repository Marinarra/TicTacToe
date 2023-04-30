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
        static Player user = new Player(' ', 0, 0, 0);
        static Player pc = new Player(' ', 0, 0, 0);
        static Board board = new Board();
        static char flagTurn = ' ', replay;
        static bool currentlyPlaying, reusableBool;

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
                //  If input is not a valid number key on keyboard, displays input as invalid and re-displays prompt
                else
                {
                    Console.Clear();
                    updateScreen();
                    WriteLine("Input is invalid! Please use either number keys");
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
        public static int convertAscii(int value)
        {
            //  Checks if value is in range 48 to 57 and then range 96 to 105. And validates number key input
            //  If value is in first range, 48 is subtracted from value
            if (value <= 57 && value >= 48)         // If numbers on top of keyboard used. 48 = 0
            {
                value -= 48;
            }
            //  If value is in second range, 96 is subtracted from value
            else if (value >= 96 && value <= 105)   // If numbers on numpad are used 96 = 0
            {
                value -= 96;
            }
            //  If value entered is not a number on the keyboard, value is set to -69 to signal invalid input
            else
            {
                value = -69;
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
            updateScreen();
            //  Used to loop game turns until match is tied or won
            do
            {
                isGameWon = (board.checkWinCondition(pc.symbol) || board.checkWinCondition(user.symbol) || board.checkTieCondition()); // checks if pc win OR user win OR tie
                //  Used to determin whether it is the systems or users turn and whether the game has ended before the next turn.
                //  Checks if the flagTurn is for the pc's symbol and if the game hasn't been won, if so the system chooses a coordinate, gives the flag to the user and then updates the screen with their move
                if (flagTurn == pc.symbol && isGameWon == false)  // system turn
                {
                    board.systemChoose(flagTurn);
                    flagTurn = user.symbol;
                    updateScreen();
                }
                //  Checks if the flagTurn is for the users symbol and if the game hasn't been won, if so the scren is updated, the user is given a coordinate selection screen and then the flag is given to the system 
                else if (flagTurn == user.symbol && isGameWon == false)  // user turn
                {
                    gameMenu();
                    flagTurn = pc.symbol;
                    updateScreen();
                }
                //  Loops while isGameWon is false and currentlyPlaying is true (isGameWon is also including if theres a tie)
            } while (isGameWon == false && currentlyPlaying == true);

            updateScreen();
            //  Used to check if the user or pc won, or if there was a tie
            //  Checks if the pc won the match, if so the pc gains a win and the user is given a loss 
            if (board.checkWinCondition(pc.symbol) == true)
            {
                pc.wins++;
                user.losses++;
            }
            //  Checks if the user won the match, if so the user gains a win and the pc is given a loss 
            if (board.checkWinCondition(user.symbol) == true)
            {
                user.wins++;
                pc.losses++;
            }
            //  Checks if there was a tie, if so both pc and user are given a tie
            else if (board.checkTieCondition() == true)
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
            //  Used to check if the game is not already quit
            //  Checks if currentlyPlaying is true, if so currentlyPlaying is assigned return value of checkIfPlayAgain
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
            //  Used to iterate until user selects valid input on whether to play again or not
            do
            {
                //  Used to check if user would like to play again and validate the answer
                //  Checks if the key pressed is the Y key, if so reusable bool is set to true and replay is set to 'Y' 
                if (keyRead.Key == ConsoleKey.Y)
                {
                    reusableBool = true;
                    replay = 'y';
                }
                //  Checks if the key pressed is the N key, if so reusable bool is set to false and replay remains 'n' 
                else if (keyRead.Key == ConsoleKey.N)
                {
                    reusableBool = false;
                }
                //  Any other key pressed is not valid, user is prompted to try again, and input valid is set to false
                else
                {
                    WriteLine("Choice unavailable, please try again Y/N \n");
                    keyRead = Console.ReadKey();
                    inputValid = false;
                }
                //  Loops while inputValid is false, input is not valid
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
            //  Used to iterate through the game cycles for each match
            do
            {

                startUpCycle(); //User selects to go first or not & user selects symbol
                RunCycle();     // User Coordinate input & RNG System choice
                ShutDown();     //Display Statistics of game and game time played and the average time
                                //  Loops while currentlyPlaying is true, user selects to replay game
            } while (currentlyPlaying == true);

        }

    }
}


