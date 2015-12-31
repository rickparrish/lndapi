using lndapi.Base;
using lndapi.VM;
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
        /// Snapshot a VM (i.e. create an image of the VM)
        /// </summary>
        /// <param name="vmId">The id of the VM to snapshot</param>
        /// <param name="name">The name to give the snapshot</param>
        /// <returns>The id for the newly created image</returns>
        /// <remarks>The method will return immediately, but it will take time to actually create the snapshot.  Use ImageDetails to check on the status.</remarks>
        public async Task<int> VMSnapshotAsync(int vmId, string name)
        {
            return (await RequestAsync<VMSnapshotResponseModel>("vm", "snapshot", new VMSnapshotRequestModel(vmId, name))).image_id;
        }
    }
}

namespace lndapi.VM
{
    public class VMSnapshotRequestModel : VMBaseRequestModel
    {
        public string name { get; set; }

        public VMSnapshotRequestModel(int vmId, string name) : base(vmId)
        {
            this.name = name;
        }
    }

    public class VMSnapshotResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {"success":"yes","image_id":"3236"}
        */
        public int image_id { get; set; }
    }
}
