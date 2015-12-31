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
        public async Task ImageDeleteAsync(int imageId)
        {
            await RequestAsync<ImageDeleteResponseModel>("image", "delete", new ImageDeleteRequestModel(imageId));
        }
    }
}

namespace lndapi.Image
{
    public class ImageDeleteRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageDeleteRequestModel(int imageId)
        {
            this.image_id = imageId;
        }
    }

    public class ImageDeleteResponseModel : BaseResponseModel
    {
        /*
        {"success":"yes"}
        NOTE: Seems to return this message whether the image existed or not
        */
    }
}
