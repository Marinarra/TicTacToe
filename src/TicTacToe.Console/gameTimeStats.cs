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
        public static int userWins = 0, userLosses = 0, ties = 0;

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

        /// <summary>
        /// Assigns current timer value to gameTime
        /// </summary>
        private static void setGameTime()
        {
            gameTime = timer.Elapsed.TotalSeconds;
        }

        /// <summary>
        /// Adds current timer value to totalGameTime
        /// </summary>
        private static void setTotalGameTIme()
        {
            totalGameTime = totalGameTime + gameTime;
        }

        /// <summary>
        /// Gets total Game Time
        /// </summary>
        /// <returns>Double, represents Total time spent accross all games</returns>
        public static double getTotalGameTime()
        {
            return totalGameTime;
        }

        /// <summary>
        /// Gets game time
        /// </summary>
        /// <returns>Double, represents time spent in most recent game</returns>
        public static double getGameTime()
        {
            return gameTime;
        }

        /// <summary>
        /// Calculates and returns average time spent across all games.
        /// Divides the total game time by the number of games played.
        /// </summary>
        /// <returns>Double, represents the average time spent in game, across all games </returns>
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
