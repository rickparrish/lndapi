using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Base
{
    // http://stackoverflow.com/a/16502192/342378
    public class NoKeepAlivesWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                ((HttpWebRequest)request).KeepAlive = false;
            }

            return request;
        }
    }
}
