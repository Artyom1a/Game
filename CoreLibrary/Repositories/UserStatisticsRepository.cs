using CoreLibrary.Models;
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
    }
}
