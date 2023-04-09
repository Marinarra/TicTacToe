﻿using System.Diagnostics;
namespace TicTacToe
{
      public static class gameTimeStats
    
      {
        static Stopwatch timer = new Stopwatch();
        private static double gameTime = 0.00, avgGameTime = 0.00,totalGameTime = 0.00;
        private static int gamesPlayed = 0;
        public static int userWins = 0, userLosses = 0, ties = 0;
        public static void startTimer()
        {
            timer.Start();
        }
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
