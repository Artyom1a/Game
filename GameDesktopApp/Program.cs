using System.ComponentModel;
using System.Text;
using GameSeaBattle;
//using GameSeaBattle.Games;
//using GameSeaBattle.Ships;
using GameSeaBattle.Boards;
using GameSeaBattle.Players;



namespace GameDesktopsApps;

public class Program
{
    private static void Main(string[] args)
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

    }

}
