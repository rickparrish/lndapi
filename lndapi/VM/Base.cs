using lndapi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.VM
{
    public class VMBaseRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMBaseRequestModel(int vmId)
        {
            this.vm_id = vmId;
        }
    }
}
