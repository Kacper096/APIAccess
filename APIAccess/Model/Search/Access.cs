using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Api.Model.Search
{
    public static class Access
    {
        private static  SummonerDTO _summoner;
        private static  string _region;

        /// <summary>
        /// Set the summoner Data. Get the summoner.
        /// </summary>
        public static SummonerDTO Summoner
        {
            get => _summoner;
            set
            {
                if (value != _summoner)
                    _summoner = value;
            }
        }
        /// <summary>
        /// Set the region Data. Get Region name.
        /// </summary>
        public static string Region
        {
            get => _region;
            set
            {
                if (value != _region)
                    _region = value;
            }
        }
        
        /// <summary>
        /// WARNING ! This clear all the data inside this class.
        /// </summary>
        public static void Clear()
        {
            _summoner = null;
            _region = string.Empty;
        }
    }
}
