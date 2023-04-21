using System;
using static System.Console;
namespace TicTacToe
{ 
    /// <summary>
    /// Displays a main menu screen with options for the user to select. 
    /// User starts, exits and views game stats via menu.
    /// </summary>
    public class MainMenu
    {

        /// <summary>
        /// Runs prints a menu screen to console forever until option is chosen/game exited via option. 
        /// Detects when user clicks a key and runs the corresponding function.
        /// </summary>
         
        static void Main(string[] args)
        {
            int option;
            while (true)
            {
                Console.Clear();
                printMenuText();
                ConsoleKeyInfo keyRead = Console.ReadKey();

                option = convertAscii(Convert.ToInt32(keyRead.Key));

                switch (option)
                {
                    case 1:
                        Game.startGame(); // new game
                        break;
                    case 2:
                        //game stats
                        gameStatsSubMenu();
                        break;
                    case 3:
                       exitGame();
                        //exit game
                        break;
                    default:
                        break;
                }

            }
            // Game.startGame();

        }

        /// <summary>
        /// Displays statistics collected during games for user to view.
        /// Shows recent game time,average and total game time. Also shows wins/losses/draws of users and system.
        /// </summary>
        private static void gameStatsSubMenu()
        {
            Console.Clear();


            WriteLine("***************************************************************************************************\n");
            WriteLine("\t## ##     ##     ##   ##  ### ###            ## ##   #### ##    ##     #### ##   ## ##   \n" +
                      "\t##   ##     ##     ## ##    ##  ##           ##   ##  # ## ##     ##    # ## ##  ##   ##  \n" +
                      "\t##        ## ##   # ### #   ##               ####       ##      ## ##     ##     ####     \n" +
                      "\t##  ###   ##  ##  ## # ##   ## ##             #####     ##      ##  ##    ##      #####   \n" +
                      "\t##   ##   ## ###  ##   ##   ##                   ###    ##      ## ###    ##         ###  \n" +
                      "\t##   ##   ##  ##  ##   ##   ##  ##           ##   ##    ##      ##  ##    ##     ##   ##  \n" +
                      "\t## ##   ###  ##  ##   ##  ### ###            ## ##    ####    ###  ##   ####     ## ##    \n");
            WriteLine("***************************************************************************************************");
            WriteLine("\n\n  ---------------------------------------------------------");

            WriteLine("{2,20} {0,20} {1:00:00} {2,2}", "Time spent in previous game:", gameTimeStats.getGameTime(),"||");
            WriteLine("{2,20} {0,20} {1:00:00} {2,8}", "Time spent on average:", (gameTimeStats.getTotalGameTime() > 0) ? gameTimeStats.getAvgGameTime() : 0, "||");
            WriteLine("{2,20} {0,20} {1:00:00} {2,5}", "Total time spent overall:", gameTimeStats.getTotalGameTime(), "||");
            WriteLine("--------------------------------------------------------------------------------------------------------------------");
            WriteLine("   ||\tUser Wins\t User Losses      ||");
            WriteLine("   ||\t{0}\t\t{1}                 ||", gameTimeStats.userWins, gameTimeStats.userLosses);
            WriteLine("   -----------------------------------------");
            WriteLine("   ||\tSystem Wins\t System Losses    ||");
            WriteLine("   ||\t{0}\t\t{1}                 ||", gameTimeStats.userLosses, gameTimeStats.userWins);
            WriteLine("  -------------------------------------------");
            WriteLine("  |\t\t  Ties: {0}\t            |", gameTimeStats.ties);
            WriteLine("  -------------------------------------------");
            WriteLine("\t\t Press any button \n");
            WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - \n");
            while (!Console.KeyAvailable) ;
            
        }

        /// <summary>
        /// Confirms that user wants to exit application when exit option on main menu is chosen.
        /// After confirmation a goodbye screen is printed, otherwise the user is returned to the main menu.
        /// </summary>
        private static void exitGame()
        {
            if(checkIfSure() == true)
            {
                Console.Clear();
                WriteLine("\n   /|__/,|   (`)' \n"+
                          "_.| o o  ) _) }\n" +
                          "-(((---(((--------\n");
                WriteLine(" Good Bye!");
                Environment.Exit(0);
            }
        }
        private static bool checkIfSure()
        {
            Console.Clear();
            bool check = false;
            WriteLine("Close application?");
            WriteLine("Press anything except Y to go back");
            WriteLine("Press Y to close application\n");
            ConsoleKeyInfo keyRead = Console.ReadKey();
            if(keyRead.Key == ConsoleKey.Y)
            {
                check = true;
            }
            return check;

        }

        public static int convertAscii(int value)
        {
            if (value <= 57 && value >= 48)
            {
                value -= 48;
            }
            else if (value >= 96 && value <= 105)
            {
                value -= 96;
            }
            return value;
        }
        private static void printMenuText()
            {
            WriteLine("***************************************************************************************************");

            string[] options = {"New Game","Game Stats","Exit Game"};
            WriteLine("\t######                          #     #\n" +
                      "\t#     #   ##   #    # ######    ##   ## ###### #    # #    # \n" +
                      "\t#        #  #  ##  ## #         # # # # #      ##   # #    # \n" +
                      "\t#  #### #    # # ## # #####     #  #  # #####  # #  # #    # \n" +
                      "\t#     # ###### #    # #         #     # #      #  # # #    # \n" +
                      "\t#     # #    # #    # #         #     # #      #   ## #    # \n" +
                      "\t######  #    # #    # ######    #     # ###### #    #  ####   \n");


            WriteLine("***************************************************************************************************");
            for (int i = 0; i < 3; i++)
                {
                    WriteLine("\t  -||============-+-> \n" +
                              "\t [→_→] {1} -+-> Press {0} (=^._.^=)∫ \n" +
                              "\t  -||============-+-> \n\n", i + 1, options[i]);
                }
            }
        


        }

    }
