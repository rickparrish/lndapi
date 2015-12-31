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
        public async Task VMResizeAsync(int vmId, int planId)
        {
            // TODO If local storage is in use, can't go down in disk size
            //      API reports success if this is attempted, but in reality nothing happens.
            //      Should I ask them to report failure in this scenario, or do I check if the resize is impossible and throw an exception?
            //      Just got an email saying resize failed.  It also indicates resizing when installing from ISO is also impossible
            await RequestAsync<VMResizeResponseModel>("vm", "resize", new VMResizeRequestModel(_BRM, vmId, planId));
        }
    }
}

namespace lndapi.VM
{
    public class VMResizeRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }
        public int plan_id { get; set; }

        public VMResizeRequestModel(BaseRequestModel brm, int vmId, int planId) : base(brm)
        {
            this.vm_id = vmId;
            this.plan_id = planId;
        }

        public override string ToString()
        {
            return $"vm_id={vm_id}&plan_id={plan_id}&{base.ToString()}";
        }
    }

    public class VMResizeResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"no","error":"invalid plan"}
        or
        {"success":"yes"}
        */
    }
}
