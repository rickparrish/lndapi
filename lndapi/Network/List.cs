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
        /// Retrieve the list of virtual networks in all regions
        /// </summary>
        /// <returns>The list of virtual networks in all regions</returns>
        public async Task<NetworkListNetworks[]> NetworkListAsync()
        {
            return await NetworkListAsync(null);
        }

        /// <summary>
        /// Retrieve the list of virtual networks in one region
        /// </summary>
        /// <returns>The list of virtual networks in the requested region</returns>
        public async Task<NetworkListNetworks[]> NetworkListAsync(string region)
        {
            return (await RequestAsync<NetworkListResponseModel>("network", "list", new NetworkListRequestModel(region))).networks;
        }
    }
}

namespace lndapi.VM
{
    public class NetworkListRequestModel : BaseRequestModel
    {
        public string region { get; set; }

        public NetworkListRequestModel(string region)
        {
            this.region = region;
        }
    }

    public class NetworkListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "networks": [
            {
              "net_id": "4",
              "name": "Luna Node",
              "subnet": "172.20.0.0\/16"
            },
            {
              "net_id": "31",
              "name": "Luna Node",
              "subnet": "172.20.0.0\/16"
            },
            {
              "net_id": "283",
              "name": "Luna Node",
              "subnet": "172.20.0.0\/16"
            }
          ]
        }
        */
        public NetworkListNetworks[] networks { get; set; }
    }

    public class NetworkListNetworks
    {
        public int net_id { get; set; }
        public string name { get; set; }
        public string subnet { get; set; }
    }
}
