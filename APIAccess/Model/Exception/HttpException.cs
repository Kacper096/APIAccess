using System.Net.Http;

namespace APIAccess.Model.Exception
{
    class HttpException : System.Exception
    {
        public HttpException()
            :base()
        {

        }
        public HttpException(string message)
            :base("Warning Server: " + message)
        {

        }

        public override string Message => base.Message;
    }
}
