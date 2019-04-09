using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Model.Exception
{
    class SummonerException : System.Exception
    {
        public SummonerException(string message)
            :base("Warning Summoner: " + message)
        {
                
        }
    }
}
