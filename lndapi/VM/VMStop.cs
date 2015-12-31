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
        public async Task VMStopAsync(int vmId)
        {
            await RequestAsync<VMStopResponseModel>("vm", "stop", new VMStopRequestModel(_BRM, vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMStopRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMStopRequestModel(BaseRequestModel brm, int vmId)
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

    public class VMStopResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"no","error":"ERROR (CommandError): Unable to stop the specified server(s)."}
        or
        {"success":"yes"}
        */
    }
}
