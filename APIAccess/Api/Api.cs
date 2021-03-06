﻿using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;


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
            Task<HttpResponseMessage> result;
            try
            {
                result =  client.GetAsync(URL);
                result.Wait();                  //Block the application
            }
            catch(HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
            catch(ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
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

        /// <summary>
        /// Gets the key from the Configuration file.
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            string str = ConfigurationManager.AppSettings["Key"].ToString();
            return str;
        }

       
        
    }
}
