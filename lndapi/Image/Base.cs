﻿using lndapi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Image
{
    /// <summary>
    /// Base request model that most Image API calls use
    /// </summary>
    public class ImageBaseRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageBaseRequestModel(int imageId)
        {
            this.image_id = imageId;
        }
    }
}