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
            var Result = await RequestAsync<VMSnapshotResponseModel>("vm", "snapshot", new VMSnapshotRequestModel(_BRM, vmId, name));
            return Result.image_id;
        }
    }
}

namespace lndapi.VM
{
    public class VMSnapshotRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }
        public string name { get; set; }

        public VMSnapshotRequestModel(BaseRequestModel brm, int vmId, string name) : base(brm)
        {
            this.vm_id = vmId;
            this.name = name;
        }

        public override string ToString()
        {
            return $"vm_id={vm_id}&name={WebUtility.UrlEncode(name)}&{base.ToString()}";
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
