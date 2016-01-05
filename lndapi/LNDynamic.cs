using lndapi.Base;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

// TODO Test everything with a restricted api key
// TODO VM DiskSwawp -- what is it?
//      {"success":"no","error":"the VM must be stopped before disk swap can proceed"}
// TODO VM floatingip-add 
// TODO VM floatingip-delete
// TODO VM create

namespace lndapi
{
    public partial class LNDynamic : IDisposable
    {
        public const string BASE_URL_LEGACY = "https://dynamic.lunanode.com/api.php";
        public const string DYNAMIC_URL = "https://dynamic.lunanode.com/api/{CATEGORY}/{ACTION}/";
        private string _APIId = null;
        private string _APIKey = null;

        public LNDynamic(string apiId, string apiKey)
        {
            if (apiId.Length != 16) throw new ArgumentException("supplied apiId incorrect length, must be 16", apiId);
            if (apiKey.Length != 128) throw new ArgumentException("supplied apiKey incorrect length, must be 128", apiKey);

            _APIId = apiId;
            _APIKey = apiKey;
        }

        private async Task<T> RequestAsync<T>(string category, string action, BaseRequestModel requestModel)
        {
            using (NoKeepAlivesWebClient WC = new NoKeepAlivesWebClient())
            {
                WC.Proxy = null;

                var Serializer = new JavaScriptSerializer();

                requestModel.api_id = _APIId;
                requestModel.api_partialkey = _APIKey.Substring(0, 64);
                string ModelData = Serializer.Serialize(requestModel);

                int Nonce = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; // https://dzone.com/articles/get-unix-epoch-time-one-line-c
                string Signature = hash_hmac("sha512", $"{category}/{action}/|{ModelData}|{Nonce.ToString()}", _APIKey);
                NameValueCollection RequestData = new NameValueCollection()
                {
                    { "req", ModelData },
                    { "signature", Signature },
                    { "nonce", Nonce.ToString() }
                };

                Uri RequestUrl = new Uri(DYNAMIC_URL.Replace("{CATEGORY}", category).Replace("{ACTION}", action));
                string ResponseText = Encoding.UTF8.GetString(await WC.UploadValuesTaskAsync(RequestUrl, "POST", RequestData));

                //if (Debugger.IsAttached)
                //{
                //    string LogFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lndapi.log");
                //    File.AppendAllText(LogFilename, $"{category}/{action}{Environment.NewLine}{ModelData}{Environment.NewLine}{ResponseText}{Environment.NewLine}{Environment.NewLine}");
                //}

                BaseResponseModel BRM = Serializer.Deserialize<BaseResponseModel>(ResponseText);
                if (BRM.success == "yes")
                {
                    return Serializer.Deserialize<T>(ResponseText);
                }
                else
                {
                    throw new LNDException(BRM.error);
                }
            }
        }

        // http://stackoverflow.com/a/12804391/342378
        private string hash_hmac(string algo, string data, string key)
        {
            // TODO algo is ignored
            var keyByte = Encoding.UTF8.GetBytes(key);
            using (var hmacsha512 = new HMACSHA512(keyByte))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(data));
                return ByteToString(hmacsha512.Hash).ToLower();
            }
        }
        private string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
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
