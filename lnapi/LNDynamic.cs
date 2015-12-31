using lndapi.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// TODO Test everything with a restricted api key
// TODO Image Fetch -- what is virtio parameter?

namespace lndapi
{
    public partial class LNDynamic : IDisposable
    {
        public const string BASE_URL_LEGACY = "https://dynamic.lunanode.com/api.php";
        private BaseRequestModel _BRM = null;

        public LNDynamic(string apiId, string apiKey)
        {
            if (apiId.Length != 16) throw new ArgumentException("supplied apiId incorrect length, must be 16", apiId);
            if (apiKey.Length != 128) throw new ArgumentException("supplied apiKey incorrect length, must be 128", apiKey);

            _BRM = new BaseRequestModel()
            {
                api_id = apiId,
                api_key = apiKey
            };
        }

        // TODO Could convert this to the newer API style instead of using legacy
        public async Task<T> RequestAsync<T>(string category, string action, BaseRequestModel requestModel)
        {
            using (WebClient WC = new WebClient())
            {
                WC.Proxy = null;

                Uri RequestUrl = new Uri($"{BASE_URL_LEGACY}?category={category}&action={action}&{requestModel.ToString()}");
                string ResponseText = await WC.DownloadStringTaskAsync(RequestUrl);

                BaseResponseModel BRM = JsonConvert.DeserializeObject<BaseResponseModel>(ResponseText);
                if (BRM.success == "yes")
                {
                    return JsonConvert.DeserializeObject<T>(ResponseText);
                }
                else
                {
                    throw new LNDException(BRM.error);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LNDynamic() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
