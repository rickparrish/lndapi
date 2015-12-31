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
            var Result = await RequestAsync<BillingCreditResponseModel>("billing", "credit", new BillingCreditRequestModel(_BRM));
            return Result.credit;
        }
    }
}

namespace lndapi.VM
{
    public class BillingCreditRequestModel : BaseRequestModel
    {
        public BillingCreditRequestModel(BaseRequestModel brm) : base(brm)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }

    public class BillingCreditResponseModel : BaseResponseModel
    {
        /*
        {"success":"yes","credit":"4.81033438"}
        */
        public double credit { get; set; }
    }
}
