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
        /// Retrieve the list of VMs
        /// </summary>
        /// <returns>The list of VMs</returns>
        public async Task<VMListVMs[]> VMListAsync()
        {
            return (await RequestAsync<VMListResponseModel>("vm", "list", new BaseRequestModel())).vms;
        }
    }
}

namespace lndapi.VM
{
    public class VMListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "vms": [
            {
              "vm_id": "1234",
              "name": "lnbackup test 1",
              "plan_id": "1",
              "hostname": "lnbackup test 1",
              "primaryip": "a.b.c.d",
              "privateip": "a.b.c.d",
              "ram": "512",
              "vcpu": "1",
              "storage": "15",
              "bandwidth": "1000",
              "region": "toronto"
            },
            {
              "vm_id": "1235",
              "name": "www-lunanode-toronto",
              "plan_id": "36",
              "hostname": "www-lunanode-toronto",
              "primaryip": "a.b.c.d",
              "privateip": "a.b.c.d",
              "ram": "4096",
              "vcpu": "4",
              "storage": "80",
              "bandwidth": "0",
              "region": "toronto"
            }
          ]
        }
        */
        public VMListVMs[] vms { get; set; }
    }

    public class VMListVMs
    {
        public int vm_id { get; set; }
        public string name { get; set; }
        public int plan_id { get; set; }
        public string hostname { get; set; }
        public string primaryip { get; set; }
        public string privateip { get; set; }
        public int ram { get; set; }
        public int vcpu { get; set; }
        public int storage { get; set; }
        public int bandwidth { get; set; }
        public string region { get; set; }
    }
}
