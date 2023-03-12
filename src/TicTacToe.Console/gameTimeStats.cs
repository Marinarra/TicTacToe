using System.Diagnostics;
namespace TicTacToe
{
      public class gameTimeStats
    
      {

        Stopwatch timer = new Stopwatch();
        private double gameTime = 0.00, avgGameTime = 0.00;

        public void startTimer()
        {
            timer.Start();
        }
        public void stopTime()
        {
            setAvgGameTime();
            setGameTime();
            timer.Reset();
        }
        private void setGameTime()
        {
            gameTime = timer.ElapsedMilliseconds;
        }
        private void setAvgGameTime()
        {
            avgGameTime = avgGameTime + timer.ElapsedMilliseconds;
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
