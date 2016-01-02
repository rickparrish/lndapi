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
        /// <summary>
        /// Replicate an image to a new region
        /// </summary>
        /// <param name="imageId">The id of the image to replicate</param>
        /// <param name="region">The region to replicate the image to</param>
        /// <returns>The id of the newly created image</returns>
        /// <remarks>The method will return immediately, but it will take time to actually replicate the image.  Use ImageReplicateAndWait if you want to wait for the image to be active before the method returns.</remarks>
        public async Task<int> ImageReplicateAsync(int imageId, string region)
        {
            return (await RequestAsync<ImageReplicateResponseModel>("image", "replicate", new ImageReplicateRequestModel(imageId, region))).image_id;
        }
    }
}

namespace lndapi.Image
{
    public class ImageReplicateRequestModel : ImageBaseRequestModel
    {
        public string region { get; set; }

        public ImageReplicateRequestModel(int imageId, string region) : base(imageId)
        {
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
