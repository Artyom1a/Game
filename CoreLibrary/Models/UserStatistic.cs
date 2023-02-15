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
        public int UserId { get; set; }
        public long Time { get; set; }

        public int GameCode { get; set; }


    }
}
