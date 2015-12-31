using lndapi.Base;
using lndapi.VM;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        public async Task<Dictionary<string, string>> RegionListAsync()
        {
            var Result = await RequestAsync<RegionListResponseModel>("region", "list", new RegionListRequestModel(_BRM));
            return Result.regions;
        }
    }
}

namespace lndapi.VM
{
    public class RegionListRequestModel : BaseRequestModel
    {
        public RegionListRequestModel(BaseRequestModel brm)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }

    public class RegionListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "regions": {
            "toronto": "Toronto, Canada",
            "montreal": "Montreal, Canada",
            "roubaix": "Roubaix, France"
          }
        }
        */
        public Dictionary<string, string> regions { get; set; }
    }
}
