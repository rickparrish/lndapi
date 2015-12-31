﻿using lnapi.Base;
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
        public async Task<int> ImageReplicateAsync(int imageId, string region)
        {
            var Result = await RequestAsync<ImageReplicateResponseModel>("image", "replicate", new ImageReplicateRequestModel(_BRM, imageId, region));
            return Result.image_id;
        }
    }
}

namespace lnapi.Image
{
    public class ImageReplicateRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }
        public string region { get; set; }

        public ImageReplicateRequestModel(BaseRequestModel brm, int imageId, string region)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
            this.image_id = imageId;
            this.region = region;
        }

        public override string ToString()
        {
            return $"image_id={image_id}&region={region}&{base.ToString()}";
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