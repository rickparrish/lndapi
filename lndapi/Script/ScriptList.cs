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
        public async Task<ScriptListScripts[]> ScriptListAsync()
        {
            var Result = await RequestAsync<ScriptListResponseModel>("script", "list", new ScriptListRequestModel(_BRM));
            return Result.scripts;
        }
    }
}

namespace lndapi.VM
{
    public class ScriptListRequestModel : BaseRequestModel
    {
        public ScriptListRequestModel(BaseRequestModel brm) : base(brm)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }

    public class ScriptListResponseModel : BaseResponseModel
    {
        /*
        {
          "success": "yes",
          "scripts": [
            {
              "id": "202",
              "name": "script label",
              "content": "content line 1\r\ncontent line 2\r\n...\r\ncontent line n"
            }
          ]
        }
        */
        public ScriptListScripts[] scripts { get; set; }
    }

    public class ScriptListScripts
    {
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
    }
}
