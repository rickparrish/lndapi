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
        public async Task VMReImageAsync(int vmId, int imageId)
        {
            await RequestAsync<VMReImageResponseModel>("vm", "reimage", new VMReImageRequestModel(_BRM, vmId, imageId));
        }
    }
}

namespace lndapi.VM
{
    public class VMReImageRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }
        public int image_id { get; set; }

        public VMReImageRequestModel(BaseRequestModel brm, int vmId, int imageId) : base(brm)
        {
            this.vm_id = vmId;
            this.image_id = imageId;
        }

        public override string ToString()
        {
            return $"vm_id={vm_id}&image_id={image_id}&{base.ToString()}";
        }
    }

    public class VMReImageResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"no","error":"invalid image selection"}
        or
        {"success":"yes"}
        */
    }
}
