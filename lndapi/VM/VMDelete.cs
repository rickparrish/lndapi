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
            await RequestAsync<VMDeleteResponseModel>("vm", "delete", new VMDeleteRequestModel(_BRM, vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMDeleteRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMDeleteRequestModel(BaseRequestModel brm, int vmId)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.vm_id = vmId;
        }

        public override string ToString()
        {
            return $"vm_id={vm_id}&{base.ToString()}";
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
