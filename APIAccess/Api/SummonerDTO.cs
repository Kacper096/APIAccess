using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Api
{
    public class SummonerDTO
    {
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public string PUUID { get; set; }
        public long SummonerLevel { get; set; }
        public long RevisionDate { get; set; }
        public string Id { get; set; }
        public string AccountId { get; set; }

    }
}
