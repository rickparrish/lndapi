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
        /// Put a VM into rescue mode
        /// </summary>
        /// <param name="vmId">The id of the VM to put into rescue mode</param>
        public async Task VMRescueAsync(int vmId)
        {
            await RequestAsync<BaseResponseModel>("vm", "rescue", new VMBaseRequestModel(vmId));
        }
    }
}