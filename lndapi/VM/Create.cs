using lndapi.Base;
using lndapi.VM;
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
        /// Create a VM
        /// </summary>
        /// <param name="hostname">The hostname to assign the new VM</param>
        /// <param name="planId">The id of the plan to create the new VM with</param>
        /// <param name="imageId">The id of the image to provision the new VM with</param>
        /// <param name="preferNode">Try to create the new VM on the same host node or a different host node</param>
        /// <param name="region">The region to create the new VM in (defaults to Toronto)</param>
        /// <param name="ip">The floating IP address to assign to the new VM (must already exist on your account)</param>
        /// <param name="networkId">The id of the virtual network to join the new VM to</param>
        /// <param name="securityGroupIds">The id(s) of the security groups to assign to the new VM</param>
        /// <param name="scriptIds">The id(s) of the startup scripts to assign to the new VM</param>
        /// <param name="volumeId">The id of the volume to boot the new VM from</param>
        /// <param name="virtio">Use virtio driver.  Provides higher disk and network throughput, but not supported by all operating systems by default (e.g. Windows)</param>
        /// <param name="keyId">The id of the SSH Key to assign to the new VM</param>
        /// <param name="setRandomPassword">Try to assign a random password to the image's administrator user (VMInfo()'s info.login_details will contain the password)</param>
        public async Task VMCreateAsync(string hostname, int planId, int imageId, VMPreferNode preferNode = VMPreferNode.NoPreference, string region = null, string ip = null, int? networkId = null, int[] securityGroupIds = null, int[] scriptIds = null, int? volumeId = null, bool? virtio = null, int? keyId = null, bool? setRandomPassword = null)
        {
            await RequestAsync<VMCreateResponseModel>("vm", "create", new VMCreateRequestModel(hostname, planId, imageId, preferNode, region, ip, networkId, securityGroupIds, scriptIds, volumeId, virtio, keyId, setRandomPassword));
        }
    }
}

namespace lndapi.VM
{
    public class VMCreateRequestModel : BaseRequestModel
    {
        public string hostname { get; set; }
        public int plan_id { get; set; }
        public int image_id { get; set; }
        public string prefer { get; set; }
        public string region { get; set; }
        public string ip { get; set; }
        public int? net_id { get; set; }
        public string securitygroups { get; set; }
        public string scripts { get; set; }
        public int? volume_id { get; set; }
        public string volume_virtio { get; set; }
        public int? key_id { get; set; }
        public string set_password { get; set; }

        public VMCreateRequestModel(string hostname, int planId, int imageId, VMPreferNode preferNode, string region, string ip, int? networkId, int[] securityGroupIds, int[] scriptIds, int? volumeId, bool? virtio, int? keyId, bool? setRandomPassword)
        {
            this.hostname = hostname;
            this.plan_id = planId;
            this.image_id = imageId;
            switch (preferNode) {
                case VMPreferNode.Distinct: this.prefer = "distinct"; break;
                case VMPreferNode.Same: this.prefer = "same"; break;
                case VMPreferNode.NoPreference: this.prefer = null; break;
            }
            this.region = region;
            this.ip = ip;
            this.net_id = networkId;
            this.securitygroups = securityGroupIds == null ? null : string.Join(",", securityGroupIds.ToArray());
            this.scripts = scripts == null ? null : string.Join(",", scripts.ToArray());
            this.volume_id = volumeId;
            this.volume_virtio = virtio == null ? null : (bool)virtio ? "yes" : "no";
            this.key_id = keyId;
            this.set_password = setRandomPassword == null ? null : (bool)setRandomPassword ? "yes" : "no";
        }
    }

    public class VMCreateResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"hostname, plan_id, and\/or image_id not set"}
        or
        {"success":"no","error":"invalid plan selection"}
        or
        {"success":"no","error":"invalid image selection"}
        or
        {"success":"yes","vm_id":"12102"}
        */
        public int vm_id { get; set; }
    }

    public enum VMPreferNode
    {
        Distinct,
        Same,
        NoPreference
    }
}
