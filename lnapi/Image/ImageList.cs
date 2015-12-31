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
        public async Task<ImageListImages[]> ImageListAsync()
        {
            return await ImageListAsync(null);
        }

        public async Task<ImageListImages[]> ImageListAsync(string region)
        {
            var Result = await RequestAsync<ImageListResponseModel>("image", "list", new ImageListRequestModel(_BRM, region));
            return Result.images;
        }
    }
}

namespace lnapi.Image
{
    public class ImageListRequestModel : BaseRequestModel
    {
        public string region { get; set; }

        public ImageListRequestModel(BaseRequestModel brm)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.region = null;
        }

        public ImageListRequestModel(BaseRequestModel brm, string region)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.region = region;
        }

        public override string ToString()
        {
            if (this.region == null)
            {
                return $"{base.ToString()}";
            }
            else
            {
                return $"region={region}&{base.ToString()}";
            }
        }
    }

    public class ImageListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "images": [
            {
              "image_id": "2685",
              "name": "Arch Linux 2015.10 64-bit (template)",
              "region": "montreal",
              "status": "active"
            },
            {
              "image_id": "2681",
              "name": "Arch Linux 2015.10.01 Dual (ISO)",
              "region": "montreal",
              "status": "active"
            }
          ]
        }
        */
        public ImageListImages[] images { get; set; }
    }

    public class ImageListImages
    {
        public int image_id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string status { get; set; }
    }
}
