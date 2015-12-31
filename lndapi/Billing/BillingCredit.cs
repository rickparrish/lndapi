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
        public async Task<double> BillingCreditAsync()
        {
            return (await RequestAsync<BillingCreditResponseModel>("billing", "credit", new BaseRequestModel())).credit;
        }
    }
}

namespace lndapi.VM
{
    public class BillingCreditResponseModel : BaseResponseModel
    {
        /*
        {"success":"yes","credit":"4.81033438"}
        */
        public double credit { get; set; }
    }
}
