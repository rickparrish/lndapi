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
            await RequestAsync<BaseResponseModel>("vm", "delete", new VMBaseRequestModel(vmId));
        }
    }
}