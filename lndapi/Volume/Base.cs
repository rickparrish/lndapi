using lndapi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Volume
{
    /// <summary>
    /// Base request model that most Volume API calls use
    /// </summary>
    public class VolumeBaseRequestModel : BaseRequestModel
    {
        public string region { get; set; }
        public int volume_id { get; set; }

        public VolumeBaseRequestModel(string region, int volumeId)
        {
            this.region = region;
            this.volume_id = volumeId;
        }
    }
}
