﻿using System;
using static System.Console;
namespace TicTacToe
{
    public class Board
    {
        private Random rng = new Random();
        private char[] board = new char[9];
        private bool checkValue;
        public Board()
        {
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i <8; i++) 
            {
                board[i] = Convert.ToChar(Convert.ToString(i + 1));
            }
        }
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
                    if( checkValue == false)
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
            for(int i = 0; i < 3; i++)
            {
                if (board[i] == flag && board[i+3] == flag && board[i+6] == flag) // each collumn 
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
               if(checkWinCondition('X') == false && checkWinCondition('O') == false)
                {
                    isTied = true;
                }
            }
            return isTied;
        }
        

        public bool checkWinCondition(char flag)
        {
            if (checkWinVertical(flag) == true)
            { return true; }
            else if (checkWinHorizontal(flag) == true)
            { return true; }
            else if (checkWinDiagnol(flag) == true)
            { return true; }
            else
            { return false; }

        }
    }
}

    


