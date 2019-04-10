using APIAccess.Model;
using APIAccess.Model.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APIAccess.Api
{
    class LeagueV4 : Api
    {
        public LeagueV4(string region) : base(region)
        {
        }

        public List<LeaguePositionDTO> GetPosition(string summonerID)
        {
            string path = string.Format(@"league/v4/positions/by-summoner/{0}", summonerID);


            try
            {
                var response = GET(GetURI(path: path));

                HttpHelper.IsHttp(response);
                string content = response.Content.ReadAsStringAsync().Result;
                
                return JsonConvert.DeserializeObject<List<LeaguePositionDTO>>(content);
               
            }
            catch (HttpException) { throw; }
            catch (SummonerException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
