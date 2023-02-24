namespace TicTacToe
{
    public class Player
    {
        char symbol;
        int wins;
        int losses;
        int ties;
        public Player()
        {
            symbol = ' ';
            wins = 0;
            losses = 0;
            ties = 0;
            
        }
        public void setPlayerSymbol(char playerSymbol)
        {
            symbol = playerSymbol;
        }
        public char getSymbol()
        {
            return symbol;
        }

        public int getPlayerWins()
        {
            return wins;
        }
        public int getPlayerLosses()
        {
            return losses;
        }
        public int getTies()
        {
            return ties;
        }

        public void addPlayerWin()
        {
            wins++;
        }
        public void addPlayerLoss()
        {
            losses++;
        }

        public void addTie()
        {
            ties++;
        }
      
       
    }
}

