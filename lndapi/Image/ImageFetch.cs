﻿using lndapi.Base;
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
        public async Task<int> ImageFetchAsync(string region, string name, string location, string format, string virtio)
        {
            var Result = await RequestAsync<ImageFetchResponseModel>("image", "fetch", new ImageFetchRequestModel(_BRM, region, name, location, format, virtio));
            return Result.image_id;
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

        public ImageFetchRequestModel(BaseRequestModel brm, string region, string name, string location, string format, string virtio)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.region = region;
            this.name = name;
            this.location = location;
            this.format = format;
            this.virtio = virtio;
        }

        public override string ToString()
        {
            return $"region={region}&name={WebUtility.UrlEncode(name)}&location={WebUtility.UrlEncode(location)}&format={format}&virtio={virtio}&{base.ToString()}";
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
}
