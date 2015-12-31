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
        public async Task<SecurityGroupListSecurityGroups[]> SecurityGroupListAsync()
        {
            return (await RequestAsync<SecurityGroupListResponseModel>("securitygroup", "list", new BaseRequestModel())).securitygroups;
        }
    }
}

namespace lndapi.VM
{
    public class SecurityGroupListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "securitygroups": [
            {
              "securitygroup_id": "4",
              "name": "default",
              "region": "toronto"
            },
            {
              "securitygroup_id": "91",
              "name": "default",
              "region": "montreal"
            },
            {
              "securitygroup_id": "258",
              "name": "default",
              "region": "roubaix"
            }
          ]
        }
        */
        public SecurityGroupListSecurityGroups[] securitygroups { get; set; }
    }

    public class SecurityGroupListSecurityGroups
    {
        public int securitygroup_id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
    }
}
