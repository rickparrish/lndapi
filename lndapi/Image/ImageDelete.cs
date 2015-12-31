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
        // NOTE: Returns success=yes whether the image existed or not
        public async Task ImageDeleteAsync(int imageId)
        {
            await RequestAsync<BaseResponseModel>("image", "delete", new ImageBaseRequestModel(imageId));
        }
    }
}