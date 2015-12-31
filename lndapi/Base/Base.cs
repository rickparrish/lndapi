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

        public BaseRequestModel()
        {
        }

        public BaseRequestModel(BaseRequestModel brm)
        {
            this.api_id = brm.api_id;
            this.api_partialkey = brm.api_partialkey.Substring(0, 64);
        }

        public override string ToString()
        {
            return $"api_id={api_id}&api_key={api_partialkey}";
        }
    }

    public class BaseResponseModel
    {
        public string success { get; set; }
        public string error { get; set; }
    }
}
