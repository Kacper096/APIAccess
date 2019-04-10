using APIAccess.Api.Model;
using APIAccess.Model.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace APIAccess.Api
{
    public class SummonerV4 : Api
    {
        public SummonerV4(string region) : base(IsRegion(region))
        {
            
        }

        public SummonerDTO GetSummonerByName(string SummonerName)
        {
            SummonerName = IsName(SummonerName);
            string path = string.Format(@"summoner/v4/summoners/by-name/{0}", SummonerName);


            try
            {
                var response = GET(GetURI(path));

                //Checks the response exception
                HttpHelper.IsHttp(response);

                string content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<SummonerDTO>(content);
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

        //Throws the typical Exception
        #region Validations
        /// <summary>
        /// Throws ArgumentNullException when region is null or empty
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private static string IsRegion(string region)
        {
            string result = string.IsNullOrEmpty(region) ? throw new RegionException("Region hasn't been found.") : region;

            return result;
        }

        /// <summary>
        /// Checks the name of summoner
        /// </summary>
        /// <param name="summoner">Summoner Name</param>
        /// <returns></returns>
        private string IsName(string name = null)
        {
            string result = string.IsNullOrEmpty(name) ? throw new SummonerException("Please write Summoner Name.") : name;
            return result;
        }

        
        #endregion
    }
}
