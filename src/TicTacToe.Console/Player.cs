namespace TicTacToe
{
   /// <summary>
   /// Stores values for each player(s): symbol,wins/losses/ties. Allows player values to be changed.
   /// </summary>
        public struct Player
        {
           public char symbol;
           public int wins;
           public int losses;
           public int ties;
        
        /// <summary>
        /// Constructor for Player struct, initializes all variables in struct.
        /// </summary>
        /// <param name="_symbol"> Represents the character for the player ('X' or 'O') </param>
        /// <param name="_wins"> Represents the number of games the player has won</param>
        /// <param name="_losses"> Represnets the numnber of games the player has lost</param>
        /// <param name="_ties">Represents the number of games the player has tied</param>
            public Player(char _symbol, int _wins, int _losses, int _ties)
            {
                symbol = _symbol;
                wins = _wins;
                losses = _losses;
                ties = _ties;
            }
    }
   
}

