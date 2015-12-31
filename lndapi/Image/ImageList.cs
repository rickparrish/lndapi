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
        /// Retrieve the list of images in all regions
        /// </summary>
        /// <returns>The list of images in all regions</returns>
        public async Task<ImageListImages[]> ImageListAsync()
        {
            return await ImageListAsync(null);
        }

        /// <summary>
        /// Retrieve the list of images in one region
        /// </summary>
        /// <param name="region">The region to retrieve the list of images from</param>
        /// <returns>The list of images in the requested region</returns>
        public async Task<ImageListImages[]> ImageListAsync(string region)
        {
            return (await RequestAsync<ImageListResponseModel>("image", "list", new ImageListRequestModel(region))).images;
        }
    }
}

namespace lndapi.Image
{
    public class ImageListRequestModel : BaseRequestModel
    {
        public string region { get; set; }

        public ImageListRequestModel(string region)
        {
            this.region = region;
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
