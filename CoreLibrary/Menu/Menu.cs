using CoreLibrary.Models;
using CoreLibrary.Controller;
using GameSeaBattle;
using GameSeaBattle.Boards;
using GameSeaBattle.Players;

namespace CoreLibrary.Menu
{
    public class Menu
    {

        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 Registration");
            Console.WriteLine("2 Authorizathion");
            Console.WriteLine("0 Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    UserController userController = new UserController();
                    (bool, User) result = userController.AddUserController();
                    return true;
                case "2":
                    UserController userController1 = new UserController();
                    (bool, User) result1 = userController1.Login();
                    if (result1.Item1 == false)
                    {
                        Console.Clear();
                        Console.WriteLine("This password incorrect");
                        Console.WriteLine("0 Exit");
                        switch (Console.ReadLine())
                        {
                            case "0":
                                return false;
                        }
                    }
                    if (result1.Item1 == true)
                    {
                        Console.Clear();
                        Console.WriteLine("1 Games");
                        Console.WriteLine("2 Delete account");
                        Console.WriteLine("3 Statistics game");
                        Console.WriteLine("0 Exit");
                        switch (Console.ReadLine())
                        {
                            case "0":
                                return false;
                            case "1":
                                Console.Clear();
                                Console.WriteLine("1 BattleShip");
                                Console.WriteLine("0 Exit");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                                                             
                                        UserStatisticsController statistics1 = new UserStatisticsController();
                                        statistics1.AddUserStat(result1.Item2,  "BattleShip");
                                        Console.Title = "Battle Ship";
                                        var User = new Users();
                                        var Bot = new Bots();
                                        Boolean yes = true;
                                        while (yes)
                                        {
                                            while (true)
                                            {
                                                User.Display(User.CopyFieldWar);
                                                User.Strike();
                                                if (User.Win())
                                                {
                                                    break;
                                                }
                                                Bot.Strike();
                                                if (Bot.Win())
                                                {
                                                    break;
                                                }
                                            }
                                            Console.SetCursorPosition(30, 1);
                                            Console.WriteLine("Thanks for playing! Do you want to play again? ");
                                            if (Console.ReadLine() != "Yes")
                                            {
                                                Console.Clear();
                                                yes = false;
                                            }
                                        }
                                        return true;
                                }
                                return true;
                            case "2":
                                userController1.Delete(result1.Item2);
                                return true;
                            case "3":

                                UserStatisticsController statistics = new UserStatisticsController();
                                statistics.GetUserStat(result1.Item2);
                                return true;
                        }
                        return true;
                    }
                    return false;

                case "4":

                case "0":
                    return false;
                default:
                    return true;
            }
        }

    }
}

