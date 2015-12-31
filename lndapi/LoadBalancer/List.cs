using lndapi.Base;
using lndapi.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        /// <summary>
        /// Retrieve the list of load balancers in one region
        /// </summary>
        /// <returns>The list of load balancers in the requested region</returns>
        public async Task<LoadBalancerListLoadBalancers[]> LoadBalancerListAsync(string region)
        {
            return (await RequestAsync<LoadBalancerListResponseModel>("lb", "list", new LoadBalancerListRequestModel(region))).lb;
        }
    }
}

namespace lndapi.VM
{
    public class LoadBalancerListRequestModel : BaseRequestModel
    {
        public string region { get; set; }

        public LoadBalancerListRequestModel(string region)
        {
            this.region = region;
        }
    }

    public class LoadBalancerListResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"region not set"}
        or
        {
          "success": "yes",
          "lb": [
            {
              "region": "toronto",
              "id": "138",
              "name": "lndapi lb"
            }
          ]
        }
        */
        public LoadBalancerListLoadBalancers[] lb { get; set; }
    }

    public class LoadBalancerListLoadBalancers
    {
        public string region { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}
