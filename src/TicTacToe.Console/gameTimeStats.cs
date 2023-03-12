using System.Diagnostics;
namespace TicTacToe
{
      public class gameTimeStats
    
      {

        Stopwatch timer = new Stopwatch();
        private double gameTime = 0.00, avgGameTime = 0.00,totalGameTime = 0.00;

        public void startTimer()
        {
            timer.Start();
        }
        public void stopTime()
        {
            setAvgGameTime();
            setGameTime();
            setTotalGameTIme();
            timer.Reset();
        }
        private void setGameTime()
        {
            gameTime = timer.Elapsed.TotalSeconds;
        }
        private void setAvgGameTime()
        {
            avgGameTime = avgGameTime + timer.Elapsed.TotalSeconds;
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
