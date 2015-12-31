using lndapi.Base;
using lndapi.Network;
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
        /// Delete a virtual network
        /// </summary>
        /// <param name="region">The name of the region to delete the virtual network from</param>
        /// <param name="netId">The id of the virtual network to delete</param>
        public async Task NetworkDeleteAsync(string region, int netId)
        {
            await RequestAsync<BaseResponseModel>("network", "delete", new NetworkDeleteRequestModel(region, netId));
        }
    }
}

namespace lndapi.Network
{
    public class NetworkDeleteRequestModel : BaseRequestModel
    {
        public string region { get; set; }
        public int net_id { get; set; }

        public NetworkDeleteRequestModel(string region, int netId)
        {
            this.region = region;
            this.net_id = netId;
        }
    }
}