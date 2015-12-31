using lndapi.Base;
using lndapi.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        public async Task<int> VMSnapshotAsync(int vmId, string name)
        {
            return (await RequestAsync<VMSnapshotResponseModel>("vm", "snapshot", new VMSnapshotRequestModel(vmId, name))).image_id;
        }
    }
}

namespace lndapi.VM
{
    public class VMSnapshotRequestModel : VMBaseRequestModel
    {
        public string name { get; set; }

        public VMSnapshotRequestModel(int vmId, string name) : base(vmId)
        {
            this.name = name;
        }
    }

    public class VMSnapshotResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"yes","image_id":"3236"}
        */
        public int image_id { get; set; }
    }
}
