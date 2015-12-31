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
        /// Retrieve the list of volumes in one region
        /// </summary>
        /// <returns>The list of volumes in the requested region</returns>
        public async Task<VolumeListVolumes[]> VolumeListAsync(string region)
        {
            return (await RequestAsync<VolumeListResponseModel>("volume", "list", new VolumeListRequestModel(region))).volumes;
        }
    }
}

namespace lndapi.VM
{
    public class VolumeListRequestModel : BaseRequestModel
    {
        public string region { get; set; }

        public VolumeListRequestModel(string region)
        {
            this.region = region;
        }
    }

    public class VolumeListResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"region not set"}
        or
        {
          "success": "yes",
          "volumes": [
            {
              "region": "toronto",
              "id": "1308",
              "name": "lndapi test",
              "size": "1",
              "status": "pending"
            }
          ]
        }
        */
        public VolumeListVolumes[] volumes { get; set; }
    }

    public class VolumeListVolumes
    {
        public string region { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string status { get; set; }
    }
}
