using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Base
{
    /// <summary>
    /// Base request model that all API calls use
    /// </summary>
    public class BaseRequestModel
    {
        public string api_id { get; set; }
        public string api_partialkey { get; set; }
    }

    /// <summary>
    /// Base response model that all API calls return
    /// </summary>
    public class BaseResponseModel
    {
        public string success { get; set; }
        public string error { get; set; }
    }
}
