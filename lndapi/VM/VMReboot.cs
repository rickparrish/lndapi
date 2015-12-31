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
        public async Task VMRebootAsync(int vmId)
        {
            await RequestAsync<VMRebootResponseModel>("vm", "reboot", new VMRebootRequestModel(vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMRebootRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMRebootRequestModel(int vmId)
        {
            this.vm_id = vmId;
        }
    }

    public class VMRebootResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"no","error":"ERROR (Conflict): Cannot 'reboot' instance <GUID> while it is in task_state reboot_started "}
        or
        {"success":"no","error":"ERROR (Conflict): Cannot 'reboot' instance <GUID> while it is in vm_state stopped "}
        or
        {"success":"yes"}
        */
    }
}
