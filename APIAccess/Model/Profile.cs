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
            var queType = Queue(position.QueueType);
            SummonerName = Access.Summoner.Name;
            Icon = string.Format(@"http://opgg-static.akamaized.net/images/profile_icons/profileIcon{0}.jpg",Access.Summoner.ProfileIconId);
            Level = Access.Summoner.SummonerLevel;
            Tier = position.Tier;
            QueueType = queType;
            Rank = IsSecondEmpty(string.Format("Rank {0}",position.Rank));
            Emblem = string.Format("/Images/Emblems/Emblem_{0}.png", Tier);
            Wins = position.Wins;
            Losses = position.Losses;
        }

        #region Data Properties
        public string SummonerName { get; }
        public string Icon { get; }
        public long Level { get; }
        public string Tier { get;  }
        public string QueueType { get; }
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

        /// <summary>
        /// Gets queue type and it renames to humanable string.
        /// </summary>
        private static string Queue(string type)
        {
            if (string.IsNullOrEmpty(type))
                return string.Empty;
            if (type.Contains("RANKED"))
                if (type.Contains("SOLO"))
                    return type = "Solo";
                else return type = "Team";

            return string.Empty;
        }

        // It's necessary to Rank property. If position.Rank is empty our Rank should be empty.
        /// <summary>
        /// It checks whether second word have any chars. If it don't have method returns string.Empty;
        /// </summary>
        /// <param name="word">Input word.</param>
        /// <returns></returns>
        private static string IsSecondEmpty(string word)
        {
            if (string.IsNullOrEmpty(word))
                return string.Empty;
            else
            {
                string[] tab = word.Split(' ');

                return string.IsNullOrEmpty(tab[1]) ? string.Empty : word;
            }
        }
    }
}
