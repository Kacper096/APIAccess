using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.Model.Exception
{
    class RegionException : System.Exception
    {
        public RegionException(string Message)
            :base("Warning Region:  " + Message)
        {

        }
    }
}
