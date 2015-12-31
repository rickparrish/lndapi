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
            await RequestAsync<ImageDeleteResponseModel>("image", "delete", new ImageDeleteRequestModel(_BRM, imageId));
        }
    }
}

namespace lndapi.Image
{
    public class ImageDeleteRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageDeleteRequestModel(BaseRequestModel brm, int imageId) : base(brm)
        {
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
