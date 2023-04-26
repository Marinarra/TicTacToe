﻿using System;
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

                option = convertAscii(Convert.ToInt32(keyRead.Key));

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
            //  Confirms if the user wants to exit the application
            //  Prints goodbye messege and exits application
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
            if(keyRead.Key == ConsoleKey.Y)
            {
                check = true;
            }
            return check;

        }
        
        /// <summary>
        /// Converts the value from the unicode value of the key to the corresponding integer.
        /// </summary>
        /// <param name="value"> Represents the unicode value of the key pressed by the user</param>
        /// <returns> A bit-32 integer, converted from unicode to its intended value.
        /// (keyboard numbers 0 to 9 = 48 to 57) (numpad numbers 0 to 9 = 96 to 105) </returns>
        public static int convertAscii(int value)
        {
            //  Checks if value is in range 48 to 57 and then range 96 to 105
            //  If value is in first range, 48 is subtracted from value
            if (value <= 57 && value >= 48)  // If numbers on top of keyboard used. 48 = 0
            {
                value -= 48;
            }
            //  If value is in second range, 96 is subtracted from value
            else if (value >= 96 && value <= 105) // If numbers on numpad are used 96 = 0
            {
                value -= 96;
            }
            return value;
        }

        /// <summary>
        /// Displays main menu to console, uses a loop to loop through 3 options and print each below the previous option and displays the number associated with each option.
        /// </summary>
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
