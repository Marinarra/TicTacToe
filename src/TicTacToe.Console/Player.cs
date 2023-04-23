namespace TicTacToe
{
   
        public struct Player
        {
           public char symbol;
           public int wins;
           public int losses;
           public int ties;
        
            public Player(char _symbol, int _wins, int _losses, int _ties)
            {
                symbol = _symbol;
                wins = _wins;
                losses = _losses;
                ties = _ties;
            }
    }
  
}

