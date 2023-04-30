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
            // Infinite loop to display main menu
            while (true)
            {
                Console.Clear();
                printMenuText();
                ConsoleKeyInfo keyRead = Console.ReadKey();

                option = Game.convertAscii(Convert.ToInt32(keyRead.Key));

                //  Determines option user chooses via input 1-3
                switch (option)
                {
                    case 1:     // If user presses 1 key
                        //new game
                        Game.startGame();
                        break;
                    case 2:    // If user presses 2 key
                        //game stats
                        gameStatsSubMenu();
                        break;
                    case 3:    // If user presses 3 key
                        exitGame();
                        //exit game
                        break;
                    default:    // If 1,2,3 keys are NOT pressed
                        break;
                }
            }
        }

        /// <summary>
        /// Displays statistics collected during games for user to view.
        /// Shows recent game time,average and total game time. Also shows wins/losses/draws of users and system.
        /// </summary>
        private static void gameStatsSubMenu()
        {
            Console.Clear();


            WriteLine("***************************************************************************************************\n");
            WriteLine("\t#####       ##    ##   ##   ######            ####    ######      ##    ######   #####  \n" +
                      "\t##   ##     ##     ## ##    ##  ##           ##   ##  # ## ##     ##    # ## ##  ##   ##  \n" +
                      "\t##        ## ##   # ### #   ##               ####       ##      ## ##     ##     ####     \n" +
                      "\t##  ###   ##  ##  ## # ##   #####             #####     ##      ##  ##    ##      #####   \n" +
                      "\t##   ##   ## ###  ##   ##   ##                   ###    ##      ######    ##         ###  \n" +
                      "\t##   ##   ##  ##  ##   ##   ##  ##           ##   ##    ##      ##  ##    ##     ##   ##  \n" +
                      "\t######   ###  ### ##   ##   ######            ####     ####    ###  ###  ####     ####    \n");
            WriteLine("***************************************************************************************************");
            WriteLine("\n\n\t\t  ----------------------------------------");

            WriteLine("{2,20} {0,20} {1:00:00} {2,2}", "Time spent in previous game:", gameTimeStats.getGameTime(), "||");
            WriteLine("{2,20} {0,20} {1:00:00} {2,8}", "Time spent on average:", (gameTimeStats.getTotalGameTime() > 0) ? gameTimeStats.getAvgGameTime() : 0, "||");
            WriteLine("{2,20} {0,20} {1:00:00} {2,5}", "Total time spent overall:", gameTimeStats.getTotalGameTime(), "||");
            WriteLine("\t\t^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            WriteLine("\t\t||\tUser Wins\t User Losses      ||");
            WriteLine("\t\t||\t   {0}\t\t\t{1}         ||", gameTimeStats.userWins, gameTimeStats.userLosses);
            WriteLine("\t\t >----------------------------------------<");
            WriteLine("\t\t||\tSystem Wins\t System Losses    ||");
            WriteLine("\t\t||\t   {0}\t\t\t{1}         ||", gameTimeStats.userLosses, gameTimeStats.userWins);
            WriteLine("\t\t--------------------------------------------");
            WriteLine("\t\t|\t\t Ties: {0}\t           |", gameTimeStats.ties);
            WriteLine("\t\t--------------------------------------------");
            WriteLine("\t\t\t Press any button \n");
            WriteLine("»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————-»»————->>\n");
            //  Used to check if user has pressed any key
            //  If any key is read as pressed then user is returned to mainMenu
            if (ReadKey().KeyChar >= 0)  //  Any key pressed, all keys have value >= 0
            {
                return;
            }
        }

        /// <summary>
        /// Confirms that user wants to exit application when exit option on main menu is chosen.
        /// After confirmation a goodbye screen is printed, otherwise the user is returned to the main menu.
        /// </summary>
        private static void exitGame()
        {
            //  Confirms if the user wants to exit the application
            //  Prints goodbye messege and exits application
            if (checkIfSure() == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("\n   /|__/,|   (`)' \n" +
                          "_.| o o  ) _) }\n" +
                          "-(((---(((--------\n");
                WriteLine(" Good Bye!");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Prompts the user to confirm they wish to exit the application.
        /// </summary>
        /// <returns> A boolean,the value is true if the user presses the 'Y' key and is false if anything else is pressed.</returns>
        private static bool checkIfSure()
        {
            Console.Clear();
            bool check = false;
            WriteLine("Close application?");
            WriteLine("Press anything except Y to go back");
            WriteLine("Press Y to close application\n");
            ConsoleKeyInfo keyRead = Console.ReadKey();
            //  Checks if console key Y is pressed
            //  Assigns value true to bool check when true
            if (keyRead.Key == ConsoleKey.Y)
            {
                check = true;
            }
            return check;

        }



        /// <summary>
        /// Displays main menu to console, uses a loop to loop through 3 options and print each below the previous option and displays the number associated with each option.
        /// </summary>
        private static void printMenuText()
        {
            WriteLine("***************************************************************************************************");

            string[] options = { "New Game", "Game Stats", "Exit Game" };
            WriteLine("\t######                          #     #\n" +
                      "\t#     #   ##   #    # ######    ##   ## ###### #    # #    # \n" +
                      "\t#        #  #  ##  ## #         # # # # #      ##   # #    # \n" +
                      "\t#  #### #    # # ## # #####     #  #  # #####  # #  # #    # \n" +
                      "\t#     # ###### #    # #         #     # #      #  # # #    # \n" +
                      "\t#     # #    # #    # #         #     # #      #   ## #    # \n" +
                      "\t######  #    # #    # ######    #     # ###### #    #  ####   \n");


            WriteLine("***************************************************************************************************");
            //  Prints out each item to console with values from options array, each iteration the next index of options is printed alongside number of the iteration + 1
            for (int i = 0; i < 3; i++)
            {
                WriteLine("\t  -||============-+-> \n" +
                          "\t [→_→] {1} -+-> Press {0} (=^._.^=)∫ \n" +
                          "\t  -||============-+-> \n\n", i + 1, options[i]);
            }
        }



    }

}
