using System.Diagnostics;
namespace TicTacToe
{
      public class gameTimeStats
    
      {

        Stopwatch timer = new Stopwatch();
        private double gameTime = 0.00, avgGameTime = 0.00,totalGameTime = 0.00;
        private int gamesPlayed = 0;
        public void startTimer()
        {
            timer.Start();
        }
        public void stopTime()
        {
            gamesPlayed = gamesPlayed + 1;
            setGameTime();
            setTotalGameTIme();
            setAvgGameTime();
            timer.Reset();
        }
        private void setGameTime()
        {
            gameTime = timer.Elapsed.TotalSeconds;
        }
        private void setAvgGameTime()
        {
            avgGameTime = ((totalGameTime) / gamesPlayed);
        }
        private void setTotalGameTIme()
        {
            totalGameTime = totalGameTime + gameTime;
        }
        public double getTotalGameTime()
        {
            return totalGameTime;
        }
        public double getGameTime()
        {
            return gameTime;
        }
        public double getAvgGameTime()
        {
            return avgGameTime;
        }
     }
}
