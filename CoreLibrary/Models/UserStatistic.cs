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
        public string GameSaveStat { get; set; }
        public string GameName { get; set; }
        public DateTime Time = DateTime.Now;
        

        public UserStatistic(int id, string gameSaveStat,string gameName)
        {
            this.Id = id;
            this.GameSaveStat = gameSaveStat;
            this.GameName = gameName;
        }

        public override string ToString()
        {
            return $"{Id} {GameName} result: {GameSaveStat} {Time}";
        }

    }
}