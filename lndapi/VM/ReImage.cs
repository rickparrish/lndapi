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
        /// Re-image a VM (i.e. re-install from a new image)
        /// </summary>
        /// <param name="vmId">The id of the VM to re-image</param>
        /// <param name="imageId">The id of the image to re-image with</param>
        public async Task VMReImageAsync(int vmId, int imageId)
        {
            await RequestAsync<BaseResponseModel>("vm", "reimage", new VMReImageRequestModel(vmId, imageId));
        }
    }
}

namespace lndapi.VM
{
    public class VMReImageRequestModel : VMBaseRequestModel
    {
        public int image_id { get; set; }

        public VMReImageRequestModel(int vmId, int imageId) : base(vmId)
        {
            this.image_id = imageId;
        }
    }
}
