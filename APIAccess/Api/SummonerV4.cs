using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Api
{
    public class SummonerV4 : Api
    {
        public SummonerV4(string region) : base(region)
        {

        }

        public SummonerDTO GetSummonerByName(string SummonerName)
        {
            string path = string.Format(@"summoner/v4/summoners/by-name/{0}", SummonerName);

            
            var response = GET(GetURI(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SummonerDTO>(content);
            }
            else return null;
           
        }
    }
}
