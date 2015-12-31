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
        public async Task<string> VMVNCAsync(int vmId)
        {
            var Result = await RequestAsync<VMVNCResponseModel>("vm", "vnc", new VMVNCRequestModel(_BRM, vmId));
            return Result.vnc_url;
        }
    }
}

namespace lndapi.VM
{
    public class VMVNCRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMVNCRequestModel(BaseRequestModel brm, int vmId)
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

    public class VMVNCResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"vnc_url":"https:\/\/toronto-ctrl.lunanode.com:6080\/vnc_auto.html?token=<GUID>","success":"yes"}
        */
        public string vnc_url { get; set; }
    }
}
