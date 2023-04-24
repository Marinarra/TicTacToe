using System.Diagnostics;
namespace TicTacToe
{
    /// <summary>
    /// Records statistics and calculates the average and total time. Also stores total player/user wins and ties.
    /// Used to display statistics in MainMenu
    /// </summary>
      public static class gameTimeStats
      {
        static Stopwatch timer = new Stopwatch();
        private static double gameTime = 0.00, avgGameTime = 0.00,totalGameTime = 0.00;
        private static int gamesPlayed = 0;
        public static int userWins = 0, userLosses = 0, ties = 0;]

        /// <summary>
        /// Starts timer from instance of Stopwatch
        /// </summary>
        public static void startTimer()
        {
            timer.Start();
        }

        /// <summary>
        /// Adds 1 to gamesPlayed, sets gameTime to recorded time,adds this time to the totalGameTime,Then resets timer.
        /// </summary>
        public static void stopTime()
        {
            gamesPlayed = gamesPlayed + 1;
            setGameTime();
            setTotalGameTIme();
            timer.Reset();
        }
        private static void setGameTime()
        {
            gameTime = timer.Elapsed.TotalSeconds;
        }
       
        private static void setTotalGameTIme()
        {
            totalGameTime = totalGameTime + gameTime;
        }
        public static double getTotalGameTime()
        {
            return totalGameTime;
        }
        public static double getGameTime()
        {
            return gameTime;
        }
        public static double getAvgGameTime()
        {
            avgGameTime = ((totalGameTime) / gamesPlayed);
            return avgGameTime;
        }

        public static void setGameWinLoss(int wins,int losses, int userTies)
        {
            userWins = wins;
            userLosses = losses;
            ties = userTies;
        }

     }
}
