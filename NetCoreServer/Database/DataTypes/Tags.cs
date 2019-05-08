using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreServer.Database.DataTypes
{
    class Tags
    {
        public enum TypeOfTags
        {
            RegistrationRequest = 0,
            LoginRequest = 1,
            SetScoreRequest = 2,
            GetScoreRequest = 3,
            GetLeaderboardsRequest = 4
        }
    }
}
