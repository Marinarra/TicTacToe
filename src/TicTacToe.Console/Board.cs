using System;
using static System.Console;
namespace TicTacToe
{
    public class Board
    {
        private Random rng = new Random();
        private char[] board = new char[9];

        public Board()
        {
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = Convert.ToChar(Convert.ToString(i+1));
            }
        }
        public bool checkIfCellAvailable(int coordinate, char flag)
        {
            if (board[coordinate] == 'X' || board[coordinate] == 'O')
            {
                WriteLine("Space Taken!");
                return false;
            } 
            
            if(coordinate <= 9 || coordinate >= 1)
            {
                board[coordinate] = flag;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void systemChoose(char flag)
        {
            int coordinate = rng.Next(8);
            while (board[coordinate] == 'X' || board[coordinate] == 'O')
            {
                coordinate = rng.Next(9);
            }
            board[coordinate] = flag;
        }

        public void printBoard()
        {

            WriteLine("\n    \t\t\t\t {0} | {1} | {2}", board[0], board[1], board[2]);
            WriteLine("    \t\t\t\t------------ ");
            WriteLine("    \t\t\t\t {0} | {1} | {2} ", board[3], board[4], board[5]);
            WriteLine("    \t\t\t\t------------ ");
            WriteLine("    \t\t\t\t {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        private bool checkWinHorizontal(char flag)
        {

            if (board[0] == flag && board[1] == flag && board[2] == flag) // first row is filled
            {
                return true;
            }
            if (board[3] == flag && board[4] == flag && board[5] == flag) // second row is filled
            {
                return true;
            }
            if (board[6] == flag && board[7] == flag && board[8] == flag) // third row is filled
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkWinVertical(char flag)
        {

            if (board[0] == flag && board[3] == flag && board[6] == flag) // first collumn is filled
            {
                return true;
            }
            if (board[1] == flag && board[4] == flag && board[7] == flag) // second collumn is filled
            {
                return true;
            }
            if (board[2] == flag && board[5] == flag && board[8] == flag) // third collumn is filled
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkWinDiagnol(char flag)
        {

            if (board[0] == flag && board[4] == flag && board[8] == flag) // top left to bottom right is filled
            {
                return true;
            }
            if (board[2] == flag && board[4] == flag && board[6] == flag) // top right to bottom left is filled
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkTieCondition()
        {
            int count = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == 'X' || board[i] == 'O')
                {
                    count++;
                }
            }
            if (count == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool checkWinCondition(char flag)
        {
            if (checkWinVertical(flag) == true)
            {
                return true;
            }
            else if (checkWinHorizontal(flag) == true)
            {
                return true;
            }
            else if (checkWinDiagnol(flag) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

