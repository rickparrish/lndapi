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
        /// Retrieve the list of DNS records
        /// </summary>
        /// <returns>The list of DNS records</returns>
        public async Task<DNSListDNS[]> DNSListAsync()
        {
            return (await RequestAsync<DNSListResponseModel>("dns", "list", new BaseRequestModel())).dns;
        }
    }
}

namespace lndapi.VM
{
    public class DNSListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "dns": [
            {
              "vm_name": "www-lunanode-toronto",
              "vm_id": "11804",
              "ip": "170.75.163.46",
              "hostname": "46.163.75.170.rdns.lunanode.com."
            },
            {
              "vm_name": "www-lunanode-toronto",
              "vm_id": "11804",
              "ip": "2602:ffb6:2:0:f816:3eff:fef4:9140",
              "hostname": "[not set]"
            }
          ]
        }
        */
        public DNSListDNS[] dns { get; set; }
    }

    public class DNSListDNS
    {
        public string vm_name { get; set; }
        public int vm_id { get; set; }
        public string ip { get; set; }
        public string hostname { get; set; }
    }
}
