using lndapi.Base;
using lndapi.Volume;
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
        /// Delete a volume
        /// </summary>
        /// <param name="region">The name of the region to delete the volume from</param>
        /// <param name="volumeId">The id of the volume to delete</param>
        public async Task VolumeDeleteAsync(string region, int volumeId)
        {
            await RequestAsync<BaseResponseModel>("volume", "delete", new VolumeBaseRequestModel(region, volumeId));
        }
    }
}