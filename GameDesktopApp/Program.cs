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
        int yes = 0;

        while (yes < 1)
        {

            User.Display(User.CopyFieldWar);
            yes++;

        }
    }
}
