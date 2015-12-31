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
        /// Retrieve the list of floating ips
        /// </summary>
        /// <returns>The list of floating ips</returns>
        public async Task<FloatingListIPs[]> FloatingListAsync()
        {
            return (await RequestAsync<FloatingListResponseModel>("floating", "list", new BaseRequestModel())).ips;
        }
    }
}

namespace lndapi.VM
{
    public class FloatingListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "ips": [
            {
              "id": "1467",
              "ip": "a.b.c.d",
              "attached_id": "11804",
              "attached_type": "vm",
              "hostname": "d.c.b.a.rdns.lunanode.com.",
              "attached_name": "www-lunanode-toronto",
              "region": "toronto"
            }
          ]
        }
        */
        public FloatingListIPs[] ips { get; set; }
    }

    public class FloatingListIPs
    {
        public int id { get; set; }
        public string ip { get; set; }
        public int attached_id { get; set; }
        public string attached_type { get; set; }
        public string hostname { get; set; }
        public string attached_name { get; set; }
        public string region { get; set; }
    }
}
