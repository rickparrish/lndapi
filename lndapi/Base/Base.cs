using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Base
{
    public class BaseRequestModel
    {
        public string api_id { get; set; }
        public string api_partialkey { get; set; }
    }

    public class BaseResponseModel
    {
        public string success { get; set; }
        public string error { get; set; }
    }
}
