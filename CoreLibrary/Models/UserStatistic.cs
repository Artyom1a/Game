using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.Models
{
    public class UserStatistic : IData
    {
        public int Id { get; set; }
        public string ResultStatisticsUser { get; set; }
        public string DenotationGame { get; set; }

        public UserStatistic(int id, string resultStatisticsUser,string denotationGame)
        {
            this.Id = id;
            this.ResultStatisticsUser = resultStatisticsUser;
            this.DenotationGame = denotationGame;
        }

        public override string ToString()
        {
            return $"User.Id - {Id}, DenotationGame-{DenotationGame} ResultStatisticsUser: {ResultStatisticsUser}";
        }

    }
}