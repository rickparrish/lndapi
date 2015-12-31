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
            return (await RequestAsync<VMVNCResponseModel>("vm", "vnc", new VMBaseRequestModel(vmId))).vnc_url;
        }
    }
}

namespace lndapi.VM
{
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
