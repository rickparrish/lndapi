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
        /// Delete an image
        /// </summary>
        /// <param name="imageId">The id of the image to delete</param>
        public async Task ImageDeleteAsync(int imageId)
        {
            await RequestAsync<BaseResponseModel>("image", "delete", new ImageBaseRequestModel(imageId));
        }
    }
}