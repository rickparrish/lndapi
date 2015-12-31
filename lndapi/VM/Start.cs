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
        /// Start a VM
        /// </summary>
        /// <param name="vmId">The id of the VM to start</param>
        public async Task VMStartAsync(int vmId)
        {
            await RequestAsync<BaseResponseModel>("vm", "start", new VMBaseRequestModel(vmId));
        }
    }
}