using lndapi.Base;
using lndapi.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        public async Task<int> ImageReplicateAsync(int imageId, string region)
        {
            return (await RequestAsync<ImageReplicateResponseModel>("image", "replicate", new ImageReplicateRequestModel(imageId, region))).image_id;
        }
    }
}

namespace lndapi.Image
{
    public class ImageReplicateRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }
        public string region { get; set; }

        public ImageReplicateRequestModel(int imageId, string region)
        {
            this.image_id = imageId;
            this.region = region;
        }
    }

    public class ImageReplicateResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid image"}
        or
        {"success":"no","error":"invalid region"}
        or
        {"success":"yes","image_id":"3260"}
        */
        public int image_id { get; set; }
    }
}
