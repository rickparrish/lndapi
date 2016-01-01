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
        /// Retrieve the details for an image
        /// </summary>
        /// <param name="imageId">The id of the image to retrieve details for</param>
        /// <returns>The details for the requested image</returns>
        public async Task<ImageDetailsDetails> ImageDetailsAsync(int imageId)
        {
            return (await RequestAsync<ImageDetailsResponseModel>("image", "details", new ImageBaseRequestModel(imageId))).details;
        }
    }
}

namespace lndapi.Image
{
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
            "size": "1376583680",
            "checksum": "972c762f6727d02399857f980c1a539d",
            "hw_vif_model": "virtio",
            "hw_disk_bus": "virtio",
            "libvirt_cpu_mode": "host-model",
            "hw_video_model": "cirrus",
            "name": "test_snapshot_via_api",
            "region": "toronto",
            "metadata": "" (sometimes "metadata": [])
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
        public string checksum { get; set; }
        public string hw_vif_model { get; set; }
        public string hw_disk_bus { get; set; }
        public string libvirt_cpu_mode { get; set; }
        public string hw_video_model { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        // TODO metadata was a string one time, and an array another time (for replicated image)
        //      Just comment out for now since we don't want deserialization to fail over something we'll likely never use
        //public string metadata { get; set; }
    }
}
