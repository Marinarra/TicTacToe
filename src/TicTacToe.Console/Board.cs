using System;
using static System.Console;
namespace TicTacToe
{
    /// <summary>
    /// Used to store functions and variables of an array board, represents a Tic-Tac-Toe board.
    /// Contains Functions for initializing char array board to be empty and show on the console as the array value + 1 (so it shows 1-9 instead of 0-8 for the user)
    /// Also contains functions to randomly generate a number within the array that is not used yet - for use to place the systems symbol at random per each turn.
    /// Contains Function to display current board array in Tic-Tac-Toe format.
    /// Lastly contains functions for checking for end conditions Win/Tie.
    /// </summary>
    public class Board
    {
        private Random rng = new Random();
        private char[] board = new char[9];
        private bool checkValue;

        /// <summary>
        /// Constructs Board class, uses initBoard function to initialize board with character values.
        /// </summary>
        public Board()
        {
            initBoard();
        }

        /// <summary>
        /// Used to assign board with character values 1-9.
        /// </summary>
        private void initBoard()
        {
            //  Assigns i value + 1 as a character to i of board array
            for (int i = 0; i < 9; i++)
            {
                board[i] = Convert.ToChar(Convert.ToString(i + 1));
            }
        }

        /// <summary>
        /// Used to determine if the coordinate given has already been taken. If the coordinate is free then the flag is assigned to the corresponding array index.
        /// </summary>
        /// <param name="coordinate">bit-32 integer, represents the coordinate to be verified</param>
        /// <param name="flag">character, represents the symbol to be placed ('X' or 'O')</param>
        /// <returns>Bool, represents whether or not the coordinated passed is valid (true = coordinate is valid, false = coordinate is already used)</returns>
        public bool checkIfCellAvailable(int coordinate, char flag)

        {
            bool result = false;
            //  Checks to see if board coordinate is taken or available
            //  If coordinate is taken, console notifies user, and result remains false
            if (board[coordinate] == 'X' || board[coordinate] == 'O')
            {
                WriteLine("\nSpace Taken!");
            }
            // If coordinate is available, board coordinate is assigned with flag char and result is changed to true
            else if (coordinate <= 8 || coordinate >= 0)
            {
                board[coordinate] = flag;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Used to determine randomly generated(rng) number within the range of board index.
        /// Places the flags symbol in the rng index of board
        /// </summary>
        /// <param name="flag"> Char,Represents the systems symbol ('X' or 'O')</param>
        public void systemChoose(char flag)
        {
            int coordinate = rng.Next(8);
            //  Assigns randomly generated number to coordinate while the coordinate contains 'X' or 'O'
            while (board[coordinate] == 'X' || board[coordinate] == 'O')
            {
                coordinate = rng.Next(9);
            }
            board[coordinate] = flag;
        }

        /// <summary>
        /// Used to display current values of board array in a Tic-Tac-Toe board layout to console
        /// </summary>
        public void printBoard()
        {

            WriteLine("\n    \t\t\t\t {0} | {1} | {2}", board[0], board[1], board[2]);
            WriteLine("    \t\t\t\t------------ ");
            WriteLine("    \t\t\t\t {0} | {1} | {2} ", board[3], board[4], board[5]);
            WriteLine("    \t\t\t\t------------ ");
            WriteLine("    \t\t\t\t {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        /// <summary>
        /// Used to reset board array back to its default initialization with initBoard
        /// </summary>
        public void resetBoard()
        {
            initBoard();
        }

        /// <summary>
        /// Used to check if the values of the board array constitute a horizontal win in Tic-Tac-Toe.
        /// Array values are checked against flag value. A bool is returned true if there is a win detected.
        /// </summary>
        /// <param name="flag">Char, represents symbol in Tic-Tac-Toe ('X' or 'O')</param>
        /// <returns>Boolean, represents whether or not the win condition has been met (true = win, false = no-win)</returns>
        private bool checkWinHorizontal(char flag)
        {
            checkValue = false;
            //  Has 3 iterations to check each row of the board
            for (int i = 0; i < 3; i++)
            {
                //  Checks if flag is the value of boards [0],[1],[2] then [3],[4],[5] then [6], [7],[8]
                if (board[i*3] == flag && board[i+1] == flag && board[i+2] == flag)  // each row
                {
                    //  Checks if the checkValue is still false
                    //  If checkValue is false then true is assigned
                    if (checkValue == false)
                    {
                        checkValue = true;
                    }
                }
            }
            return checkValue;
        }

        /// <summary>
        /// Used to check if the values of the board array constitute a vertical win in Tic-Tac-Toe.
        /// Array values are checked against flag value. A bool is returned true if there is a win detected.        
        /// </summary>
        /// <param name="flag">Char, represents symbol in Tic-Tac-Toe ('X' or 'O')</param>
        /// <returns>Boolean, represents whether or not the win condition has been met (true = win, false = no-win)</returns>
        private bool checkWinVertical(char flag)
        {
            checkValue = false;
            //  Has 3 iterations to check each collumn of the board 
            for (int i = 0; i < 3; i++)
            {
                //  Checks if flag is the value of boards [0],[3],[6] then [1],[4],[7] then [2],[5],[8]
                if (board[i] == flag && board[i + 3] == flag && board[i + 6] == flag) // each collumn 
                {
                    //  Checks if the checkValue is still false
                    //  If checkValue is false then true is assigned
                    if (checkValue == false)
                    {
                        checkValue = true;
                    }
                }
            }
            return checkValue;
        }

        /// <summary>
        /// Used to check if the values of the board array constitute a diagnol win in Tic-Tac-Toe.
        /// Array values are checked against flag value. A bool is returned true if there is a win detected.        
        /// </summary>
        /// <param name="flag">Char, represents symbol in Tic-Tac-Toe ('X' or 'O')</param>
        /// <returns>Boolean, represents whether or not the win condition has been met (true = win, false = no-win)</returns>
        private bool checkWinDiagnol(char flag)
        {
            checkValue = false;

            //  Checks if board[0],board[4],board[8] all contain flag, if true sets checkValue to true
            if (board[0] == flag && board[4] == flag && board[8] == flag) // top left to bottom right is filled
            {
                checkValue = true;
            }
            //  Checks if board[2],board[4],board[6] all contain flag, if true sets checkValue to true
            if (board[2] == flag && board[4] == flag && board[6] == flag) // top right to bottom left is filled
            {
                checkValue = true;
            }
            return checkValue;

        }

        /// <summary>
        /// Used to check if the board arrays current values constitute a tie condition in Tic-Tac-Toe (if all cells are filled with 'X' or 'O').
        /// </summary>
        /// <returns>Boolean, represents whether or not the tie condition has been met (true = tie, false = no-tie)</returns>
        public bool checkTieCondition()
        {
            bool isTied = false;
            int count = 0;
            //  Has 9 iterations to check each index of the board
            for (int i = 0; i < board.Length; i++)
            {
                //  Checks if board index i contains 'X' OR 'O', if it contains one then count + 1
                if (board[i] == 'X' || board[i] == 'O')
                {
                    count++;
                }
            }
            //  Checks if count equals 9 then win conditions are checked
            if (count == 9)
            {
                //  if there is no win condition that is true for either 'X' or 'O' then isTied = true
                if (checkWinCondition('X') == false && checkWinCondition('O') == false)
                {
                    isTied = true;
                }
            }
            return isTied;
        }

        /// <summary>
        /// Used to call all check functions for win conditions (vertical,horizontal and diagnol).
        /// </summary>
        /// <param name="flag">Char, represents symbol in Tic-Tac-Toe ('X' or 'O')</param>
        /// <returns>Boolean, represents whether any win conditions have been met (true = a win condition met, false = no win conditions met)</returns>
        public bool checkWinCondition(char flag)
        {
            checkValue = false;
            //  Checks if any win condition returns true, if any one condition is true then checkValue is assigned true
            if (checkWinVertical(flag) || checkWinHorizontal(flag) || checkWinDiagnol(flag))
            { checkValue = true; }
            return checkValue;

        }
    }
}




