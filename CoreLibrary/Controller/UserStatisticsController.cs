using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Models;
using CoreLibrary.Services;

namespace CoreLibrary.Controller
{
    public class UserStatisticsController
    {
        public UserStatisticsService userStatisticsService = new UserStatisticsService();

        public bool GetAllStats()
        {
            List<UserStatistic> stats = userStatisticsService.GetAllStats();
            if (stats == null)
            {
                Console.WriteLine($"Statistic yet no");
                return false;
            }
            for (int i = 0; i < stats.Count; i++)
            {
                Console.WriteLine(stats[i]);
            }
            return true;
        }

        public bool GetUserStat(Models.User user)
        {
            List<UserStatistic> stats = userStatisticsService.GetStatsUser(user.Id);
            if (stats == null)
            {
                Console.WriteLine($"Statistic {user.Name} no");
                return false;
            }
            for (int i = 0; i < stats.Count; i++)
            {
                Console.WriteLine($"User {user.Name} {stats[i]}");
            }
            return true;
        }


        public bool AddUserStat(Models.User user, string gameResult, string gameName)
        {
            if (user != null && gameResult != null)
            {
                UserStatistic stats = new UserStatistic(user.Id, gameResult, gameName);
                userStatisticsService.AddUserStats(stats);
                return true;
            }
            return false;

        }

    }
}

  