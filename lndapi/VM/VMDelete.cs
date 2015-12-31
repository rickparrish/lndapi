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
        public async Task VMDeleteAsync(int vmId)
        {
            await RequestAsync<VMDeleteResponseModel>("vm", "delete", new VMDeleteRequestModel(vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMDeleteRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMDeleteRequestModel(int vmId)
        {
            this.vm_id = vmId;
        }
    }

    public class VMDeleteResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"yes"}
        */
    }
}
