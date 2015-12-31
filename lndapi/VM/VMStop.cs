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
            await RequestAsync<VMStopResponseModel>("vm", "stop", new VMStopRequestModel(vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMStopRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMStopRequestModel(int vmId)
        {
            this.vm_id = vmId;
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
