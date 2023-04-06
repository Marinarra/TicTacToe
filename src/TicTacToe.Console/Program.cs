using static System.Console;
namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {

            printMenuText();
            // Game.startGame();

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
