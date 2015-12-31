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
        public async Task VMStartAsync(int vmId)
        {
            await RequestAsync<VMStartResponseModel>("vm", "start", new VMStartRequestModel(_BRM, vmId));
        }
    }
}

namespace lndapi.VM
{
    public class VMStartRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMStartRequestModel(BaseRequestModel brm, int vmId) : base(brm)
        {
            this.vm_id = vmId;
        }

        public override string ToString()
        {
            return $"vm_id={vm_id}&{base.ToString()}";
        }
    }

    public class VMStartResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"no","error":"ERROR (CommandError): Unable to start the specified server(s)."}
        or
        {"success":"yes"}
        */
    }
}
