using System;
using System.Configuration;
using System.IO;
using System.Net.Http;

namespace APIAccess.Api
{
    public class Api
    {
        public string Key { get; set; }
        public string Region { get; set; }

        public Api(string region)
        {
            Region = region;
            Key = GetKey();
        }

        protected HttpResponseMessage GET(string URL)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseProxy = false });
            var result = client.GetAsync(URL);
            try
            {
                result.Wait();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return result.Result;
        }

        protected string GetURI(string path)
        {
            string protocol = ConfigurationManager.AppSettings["Protocol"].ToString();
            string domain = ConfigurationManager.AppSettings["Domain"].ToString();
            string apiconfig = ConfigurationManager.AppSettings["AppConfig"].ToString();
            string str = protocol + Region + domain + path + apiconfig + Key;

            return str;
        }

        public string GetKey()
        {
            string str = ConfigurationManager.AppSettings["Key"].ToString();
            return str;
        }
    }
}
