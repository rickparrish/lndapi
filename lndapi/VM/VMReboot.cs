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
        /// Reboot a VM
        /// </summary>
        /// <param name="vmId">The id of the VM to reboot</param>
        public async Task VMRebootAsync(int vmId)
        {
            await RequestAsync<BaseResponseModel>("vm", "reboot", new VMBaseRequestModel(vmId));
        }
    }
}
