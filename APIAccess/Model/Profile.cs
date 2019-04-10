using APIAccess.Api;
using APIAccess.Api.Model;
using APIAccess.Api.Model.Search;
using System.Linq;


namespace APIAccess.Model
{
    public class Profile
    {
        public Profile()
        {
            var position = Profile.GetLeaguePosition(Access.Summoner);
            SummonerName = Access.Summoner.Name;
            Icon = Access.Summoner.PUUID;
            Level = Access.Summoner.SummonerLevel;
            Tier = position.Tier;
            Rank = position.Rank;
            Emblem = string.Format("/Images/Emblems/Emblem_{0}.png", Tier);
            Wins = position.Wins;
            Losses = position.Losses;
        }

        #region Data Properties
        public string SummonerName { get; }
        public string Icon { get; }
        public long Level { get; }
        public string Tier { get;  }
        public string Rank { get; }
        public string Emblem { get; }
        public int Wins { get; }
        public int Losses { get; }
        #endregion

        /// <summary>
        /// Get the League Position.
        /// </summary>
        /// <param name="summoner"></param>
        /// <returns></returns>
        private static LeaguePositionDTO GetLeaguePosition(SummonerDTO summoner)
        {
            LeagueV4 league = new LeagueV4(Access.Region);

            var position = league.GetPosition(summoner.Id).Where(p => p.QueueType.Contains("RANKED_SOLO_5x5")).FirstOrDefault();

            return position ?? new LeaguePositionDTO();
        }
    }
}
