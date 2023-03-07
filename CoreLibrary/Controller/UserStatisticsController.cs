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
            List<UserStatistic> statistics = userStatisticsService.GetAllStats();
            if (statistics == null)
            {
                Console.WriteLine($"No results");
                return false;
            }
            for (int i = 0; i < statistics.Count; i++)
            {
                Console.WriteLine(statistics[i]);
            }
            return true;
        }

        public bool GetUserStatistics(User user)
        {
            List<UserStatistic> statistics = userStatisticsService.GetStatsUser(user.Id);
            if (statistics == null)
            {
                Console.WriteLine($"No results");
                return false;
            }
            for (int i = 0; i < statistics.Count; i++)
            {
                Console.WriteLine($"{user.Name} {statistics[i]}");
            }
            return true;
        }


        public bool AddUserStat(User user, string resultStatistics, string denotationgame= "BattleShip")
        {
            if (user != null && resultStatistics != null)
            {
                UserStatistic statistics = new UserStatistic(user.Id, resultStatistics, denotationgame);
                userStatisticsService.AddUserStats(statistics);
                return true;
            }
            return false;

        }

    }
}

  