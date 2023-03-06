using CoreLibrary.Models;
using CoreLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreLibrary.Repositories
{
    public class UserStatisticsRepository : BaseRepository<UserStatistic>
    {
        protected override string Path => "C:\\Code Main\\usersstatistic.txt";

        public void AddUserStats(UserStatistic userStats)
        {
            if (userStats == null) throw new ArgumentNullException(nameof(userStats));
            List<UserStatistic> users = GetAll().ToList();
            users.Add(userStats);
            OverWritingFile(users);
        }

        public List<UserStatistic> GetUserStats(int id)
        {
            List<UserStatistic> users = GetAll().ToList();
            List<UserStatistic> stats = new List<UserStatistic>();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    stats.Add(users[i]);
                }
            }
            return stats;
        }

        public List<UserStatistic> GetAllStats()
        {
            List<UserStatistic> users = GetAll().ToList();
            return users;
        }
    }
}