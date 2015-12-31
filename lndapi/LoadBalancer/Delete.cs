using lndapi.Base;
using lndapi.LoadBalancer;
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
        /// Delete a load balancer
        /// </summary>
        /// <param name="region">The name of the region to delete the load balancer from</param>
        /// <param name="lbId">The id of the load balancer to delete</param>
        public async Task LoadBalancerDeleteAsync(string region, int lbId)
        {
            await RequestAsync<BaseResponseModel>("lb", "delete", new LoadBalancerDeleteRequestModel(region, lbId));
        }
    }
}

namespace lndapi.LoadBalancer
{
    public class LoadBalancerDeleteRequestModel : BaseRequestModel
    {
        public string region { get; set; }
        public int lb_id { get; set; }

        public LoadBalancerDeleteRequestModel(string region, int lbId)
        {
            this.region = region;
            this.lb_id = lbId;
        }
    }
}