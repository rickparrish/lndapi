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
        public async Task<ImageDetailsDetails> ImageDetailsAsync(int imageId)
        {
            var Result = await RequestAsync<ImageDetailsResponseModel>("image", "details", new ImageDetailsRequestModel(imageId));
            return Result.details;
        }
    }
}

namespace lndapi.Image
{
    public class ImageDetailsRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageDetailsRequestModel(int imageId)
        {
            this.image_id = imageId;
        }
    }

    public class ImageDetailsResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid image"}
        or
        {
          "success": "yes",
          "details": {
            "time_created": "2015-12-30T01:24:28.000000",
            "status": "queued",
            "size": "0",
            "hw_vif_model": "virtio",
            "hw_disk_bus": "virtio",
            "libvirt_cpu_mode": "host-model",
            "hw_video_model": "cirrus",
            "name": "test_snapshot_via_api",
            "region": "toronto",
            "metadata": ""
          }
        }
        */
        public ImageDetailsDetails details { get; set; }
    }

    public class ImageDetailsDetails
    {
        public string time_created { get; set; } // TODO DateTime?
        public string status { get; set; }
        public long size { get; set; }
        public string hw_vif_model { get; set; }
        public string hw_disk_bus { get; set; }
        public string libvirt_cpu_mode { get; set; }
        public string hw_video_model { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public Dictionary<string, string> metadata { get; set; }
    }
}
