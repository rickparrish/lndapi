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
        /// Stop a VM
        /// </summary>
        /// <param name="vmId">The id of the VM to stop</param>
        public async Task VMStopAsync(int vmId)
        {
            await RequestAsync<BaseResponseModel>("vm", "stop", new VMBaseRequestModel(vmId));
        }
    }
}
