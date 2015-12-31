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
        public async Task<PlanListPlans[]> PlanListAsync()
        {
            var Result = await RequestAsync<PlanListResponseModel>("plan", "list", new PlanListRequestModel(_BRM));
            return Result.plans;
        }
    }
}

namespace lndapi.VM
{
    public class PlanListRequestModel : BaseRequestModel
    {
        public PlanListRequestModel(BaseRequestModel brm)
        {
            this.api_id = brm.api_id;
            this.api_key = brm.api_key;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }

    public class PlanListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "plans": [
            {
              "plan_id": "1",
              "name": "512 MB",
              "ram": "512",
              "vcpu": "1",
              "storage": "15",
              "bandwidth": "1000",
              "ips": "30",
              "price": "0.005",
              "category": "SSD-Cached",
              "metadata_json": "",
              "price_nice": "$0.005",
              "metadata": ""
            },
            {
              "plan_id": "2",
              "name": "1024 MB",
              "ram": "1024",
              "vcpu": "2",
              "storage": "20",
              "bandwidth": "1500",
              "ips": "30",
              "price": "0.0072",
              "category": "SSD-Cached",
              "metadata_json": "",
              "price_nice": "$0.0072",
              "metadata": ""
            }
          ]
        }
        */
        public PlanListPlans[] plans { get; set; }
    }

    public class PlanListPlans
    {
        public int plan_id { get; set; }
        public string name { get; set; }
        public int ram { get; set; }
        public int vcpu { get; set; }
        public int storage { get; set; }
        public int bandwidth { get; set; }
        public int ips { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string metadata_json { get; set; }
        public string price_nice { get; set; }
        public Dictionary<string, string> metadata { get; set; }
    }
}
