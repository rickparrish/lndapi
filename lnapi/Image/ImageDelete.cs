using lnapi.Base;
using lnapi.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lnapi
{
    public partial class LNDynamic
    {
        public async Task ImageDeleteAsync(int imageId)
        {
            await RequestAsync<ImageDeleteResponseModel>("image", "delete", new ImageDeleteRequestModel(_BRM, imageId));
        }
    }
}

namespace lnapi.Image
{
    public class ImageDeleteRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageDeleteRequestModel(BaseRequestModel brm, int imageId)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.image_id = imageId;
        }

        public override string ToString()
        {
            return $"image_id={image_id}&{base.ToString()}";
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
