using lndapi.Base;
using lndapi.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        /// <summary>
        /// Fetch an image from an external source (i.e. upload an image from an external source to your account)
        /// </summary>
        /// <param name="region">The region to store the image</param>
        /// <param name="name">The name to give the image</param>
        /// <param name="location">The full http:// url to the image</param>
        /// <param name="format">The format of the image</param>
        /// <param name="virtio">Use virtio driver.  Provides higher disk and network throughput, but not supported by all operating systems by default (e.g. Windows)</param>
        /// <returns>The id of the newly created image</returns>
        /// <remarks>The method will return immediately, but it will take time to actually fetch the image.  Use ImageDetails to check on the status.</remarks>
        public async Task<int> ImageFetchAsync(string region, string name, string location, ImageFormat format, bool virtio)
        {
            return (await RequestAsync<ImageFetchResponseModel>("image", "fetch", new ImageFetchRequestModel(region, name, location, format, virtio))).image_id;
        }
    }
}

namespace lndapi.Image
{
    public class ImageFetchRequestModel : BaseRequestModel
    {
        public string region { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string format { get; set; }
        public string virtio { get; set; }

        public ImageFetchRequestModel(string region, string name, string location, ImageFormat format, bool virtio)
        {
            this.region = region;
            this.name = name;
            this.location = location;
            switch (format) {
                case ImageFormat.ISO: this.format = "iso"; break;
                case ImageFormat.QCOW2: this.format = "qcow2"; break;
            }
            this.virtio = virtio ? "yes" : "no";
        }
    }

    public class ImageFetchResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid region"}
        or
        {"success":"yes","image_id":"3260"}
        */
        public int image_id { get; set; }
    }

    public enum ImageFormat
    {
        ISO,
        QCOW2
    }
}
