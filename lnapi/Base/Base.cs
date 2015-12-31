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
        public string api_key { get; set; }

        public override string ToString()
        {
            return $"api_id={api_id}&api_key={api_key}";
        }
    }

    public class BaseResponseModel
    {
        public string success { get; set; }
        public string error { get; set; }
    }
}
