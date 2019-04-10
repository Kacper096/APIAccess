using APIAccess.Model.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Api
{
    static class HttpHelper
    {
        /// <summary>
        /// Throws exception when Http push exception. I wrote this method, because HttpClient don't pushes exceptions.
        /// </summary>
        /// <param name="message"></param>
        public static void IsHttp(HttpResponseMessage message)
        {
            switch (message.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new SummonerException("Summoner name hasn't been found. Checks your name.");
                case HttpStatusCode.Forbidden:
                    throw new HttpException("You don't have access.");
                case HttpStatusCode.GatewayTimeout:
                    throw new HttpException("Timeout. Try connect again.");
                case HttpStatusCode.BadGateway:
                    throw new HttpException("Refresh the connection.");
                case HttpStatusCode.OK:
                    break;
            }
        }
    }
}
