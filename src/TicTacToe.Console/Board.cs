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

            if (board[coordinate] == 'X' || board[coordinate] == 'O')
            {
                WriteLine("\nSpace Taken!");
            }
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
        public void resetBoard()
        {
            initBoard();
        }

        private bool checkWinHorizontal(char flag)
        {
            checkValue = false;
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == flag && board[i + 1] == flag && board[i + 2] == flag)  // each row
                {
                    if (checkValue == false)
                    {
                        checkValue = true;
                    }
                }
            }
            return checkValue;
        }

        private bool checkWinVertical(char flag)
        {
            checkValue = false;
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == flag && board[i + 3] == flag && board[i + 6] == flag) // each collumn 
                {
                    if (checkValue == false)
                    {
                        checkValue = true;
                    }
                }
            }
            return checkValue;
        }
        private bool checkWinDiagnol(char flag)
        {
            checkValue = false;

            if (board[0] == flag && board[4] == flag && board[8] == flag) // top left to bottom right is filled
            {
                checkValue = true;
            }
            if (board[2] == flag && board[4] == flag && board[6] == flag) // top right to bottom left is filled
            {
                checkValue = true;
            }
            return checkValue;

        }

        public bool checkTieCondition()
        {
            bool isTied = false;
            int count = 0;
            for (int i = 0; i < board.Length; i++)
            {

                if (board[i] == 'X' || board[i] == 'O')
                {
                    count++;
                }
            }
            if (count == 9)
            {
                if (checkWinCondition('X') == false && checkWinCondition('O') == false)
                {
                    isTied = true;
                }
            }
            return isTied;
        }


        public bool checkWinCondition(char flag)
        {
            checkValue = false;
            if (checkWinVertical(flag) || checkWinHorizontal(flag) || checkWinDiagnol(flag))
            { checkValue = true; }
            return checkValue;

        }
    }
}

    


