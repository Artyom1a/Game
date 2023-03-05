using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Models;
using CoreLibrary.Repositories;

namespace CoreLibrary.Services
{
    public class UserStatisticsService
    {

        private readonly UserStatisticsRepository userStatisticsRepository = new UserStatisticsRepository();

        public List<UserStatistic> GetAllStats()
        {
            return userStatisticsRepository.GetAllStats();
        }
        public List<UserStatistic> GetStatsUser(int id)
        {
            return userStatisticsRepository.GetUserStats(id);
        }
        public void AddUserStats(UserStatistic userStats)
        {
            userStatisticsRepository.AddUserStats(userStats);
        }
    }
}

