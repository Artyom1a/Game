using GameDesktopsApps;
using GameSeaBattle.Players;

namespace Games.Core
{
    public class GamesCore
    {
        public string ResultStatistics { get; set; }
        public int UserControllerId { get; set; }

        public GamesCore(int userControllerId, string resultStatistics = "")
        {
            ResultStatistics = resultStatistics;
            UserControllerId = userControllerId;
        }

        public void Menu()
        {
            Console.Title = "Battle Ship";

            var User = new Users();
            var Bot = new Bots();
            Boolean yes = true;
            while (yes)
            {
                while (true)
                {
                    User.Display(User.CopyFieldWar);


                    //---------------------------------
                    //User.Win();
                    //ResultStatistics = "User Win";
                    //break;
                    //---------------------------------
                    Bot.Win();
                    ResultStatistics = "Bot Win";
                    break;


                    //---------------------------------
                    //User.Strike();
                    //if (User.Win())
                    //{
                    //    ResultStatistics = "User Win";
                    //    break;
                    //}
                    //Bot.Strike();
                    //if (Bot.Win())
                    //{
                    //    ResultStatistics = "Bot Win";
                    //    break;
                    //}
                }
                Console.SetCursorPosition(30, 1);
                Console.WriteLine("Thanks for playing! Do you want to play again? ");
                if (Console.ReadLine() != "Yes")
                {
                    Console.Clear();
                    yes = false;
                }
            }
        }
    }

}

