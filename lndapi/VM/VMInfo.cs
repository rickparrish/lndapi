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
        public async Task<VMInfoInfo> VMInfoAsync(int vmId)
        {
            var Result = await RequestAsync<VMInfoResponseModel>("vm", "info", new VMInfoRequestModel(vmId));
            return Result.info;
        }
    }
}

namespace lndapi.VM
{
    public class VMInfoRequestModel : BaseRequestModel
    {
        public int vm_id { get; set; }

        public VMInfoRequestModel(int vmId)
        {
            this.vm_id = vmId;
        }
    }

    public class VMInfoResponseModel : BaseResponseModel
    {
        /*
        {"success":"no","error":"invalid vm"}
        or
        {
          "info": {
            "hostname": "lnbackup test 1",
            "addresses": [
              {
                "addr": "a:b:c:d:e:f:g:h",
                "version": "6",
                "external": "1"
              },
              {
                "addr": "a.b.c.d",
                "version": "4",
                "external": ""
              },
              {
                "addr": "a.b.c.d",
                "version": "4",
                "external": ""
              },
              {
                "addr": "a.b.c.d",
                "version": "4",
                "external": "1"
              },
              {
                "addr": "a.b.c.d",
                "version": "4",
                "external": "1"
              }
            ],
            "status": "&lt;font color=&quot;green&quot;&gt;&lt;b&gt;Online&lt;\/b&gt;&lt;\/font&gt;",
            "status_raw": "active",
            "status_color": "green",
            "image": "Ubuntu 14.04 64-bit (template)",
            "security_groups": [
              "group_string"
            ],
            "status_nohtml": "Online",
            "os": "Ubuntu 14.04 64-bit (template)",
            "securitygroups": [
              "group_string"
            ],
            "additionalip": [
              "a.b.c.d"
            ],
            "additionalprivateip": [
              "a.b.c.d"
            ],
            "ipv6": [
              "a:b:c:d:e:f:g:h"
            ],
            "privateip": "a.b.c.d",
            "ip": "a.b.c.d",
            "login_details": "username: ubuntu; password: password"
          },
          "extra": {
            "vm_id": "12000",
            "name": "lnbackup test 1",
            "plan_id": "1",
            "hostname": "lnbackup test 1",
            "primaryip": "a.b.c.d",
            "privateip": "a.b.c.d",
            "ram": "512",
            "vcpu": "1",
            "storage": "15",
            "bandwidth": "1000",
            "region": "toronto"
          },
          "success": "yes"
        }
        */
        public VMInfoInfo info { get; set; }
        public VMInfoExtra extra { get; set; }
    }

    public class VMInfoInfo
    {
        public string hostname { get; set; }
        public VMInfoInfoAddresses[] addresses { get; set; }
        public string status { get; set; }
        public string status_raw { get; set; }
        public string status_color { get; set; }
        public string image { get; set; }
        public string[] security_groups { get; set; }
        public string status_nohtml { get; set; }
        public string os { get; set; }
        public string[] additionalip { get; set; } // TODO string[]?
        public string[] additionalprivateip { get; set; } // TODO string[]?
        public string[] ipv6 { get; set; }
        public string privateip { get; set; }
        public string ip { get; set; }
        public string login_details { get; set; }
    }

    public class VMInfoInfoAddresses
    {
        public string addr { get; set; }
        public int version { get; set; }
        public string external { get; set; }
    }

    public class VMInfoExtra
    {
        public int vm_id { get; set; }
        public string name { get; set; }
        public int plan_id { get; set; }
        public string hostname { get; set; }
        public string primaryip { get; set; }
        public string privateip { get; set; }
        public int ram { get; set; }
        public int vcpu { get; set; }
        public int storage { get; set; }
        public int bandwidth { get; set; }
        public string region { get; set; }
    }
}
