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
            return (await RequestAsync<RegionListResponseModel>("region", "list", new BaseRequestModel())).regions;
        }
    }
}

namespace lndapi.VM
{
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
