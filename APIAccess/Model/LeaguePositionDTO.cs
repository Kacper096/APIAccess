using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Model
{
    public class LeaguePositionDTO
    {
        public string QueueType { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Rank { get; set; }
        public string Tier { get; set; }
    }
}
