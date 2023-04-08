using System;
using static System.Console;
namespace TicTacToe
{
    public class Program
    {


        static void Main(string[] args)
        {
            int option;
            while (true)
            {
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
                        //exit game
                        break;
                    default:
                        break;
                }

            }
            // Game.startGame();

        }

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
            WriteLine("\n\n-----------------------------------");
            
            WriteLine("\t\t Time spent in game: {0:00:00}" +
                    "\n\t\t Time spent on average: {1:00:00} " +
                    "\n\t\t Total time spent across all games: {2:00:00} ", gameTimeStats.getGameTime(), gameTimeStats.getAvgGameTime(), gameTimeStats.getTotalGameTime());

        }

        private static void exitGame()
        {

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
            string[] options = {"New Game","Game Stats","Exit Game"};
            WriteLine(" \t######                         #     #\n" +
                      "\t#     #   ##   #    # ######    ##   ## ###### #    # #    # \n" +
                      "\t#        #  #  ##  ## #         # # # # #      ##   # #    # \n" +
                      "\t#  #### #    # # ## # #####     #  #  # #####  # #  # #    # \n" +
                      "\t#     # ###### #    # #         #     # #      #  # # #    # \n" +
                      "\t#     # #    # #    # #         #     # #      #   ## #    # \n" +
                      "\t#####  #    # #    # ######    #     # ###### #    #  ####   \n");
                                                              


                WriteLine("**************************************** \n");
                for (int i = 0; i < 3; i++)
                {
                    WriteLine("\t  -||============-+-> \n" +
                              "\t [{0}] {1} {0} -+-> Press {0} (=^._.^=)∫ \n" +
                              "\t  -||============-+-> \n\n", i + 1, options[i]);
                }
            }
        


        }

    }
