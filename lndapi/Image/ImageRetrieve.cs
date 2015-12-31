using lndapi.Base;
using lndapi.Image;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        public async Task ImageRetrieveAsync(int imageId, string filename, EventHandler<ImageRetrieveProgressChangedEventArgs> eventHandler)
        {
            //TODO var Details = await this.ImageDetailsAsync(1234);

            using (WebClient WC = new WebClient())
            {
                WC.Proxy = null;
                if (eventHandler != null)
                {
                    WC.DownloadProgressChanged += (s, e) =>
                    {
                        //TODO eventHandler(s, new ImageRetrieveProgressChangedEventArgs(e.BytesReceived, e.TotalBytesToReceive > 0 ? e.TotalBytesToReceive : Details.details.size));
                    };
                }

                Uri RetrieveImageUrl = new Uri($"{BASE_URL_LEGACY}?category=image&action=retrieve&image_id={imageId}&{_BRM.ToString()}");
                await WC.DownloadFileTaskAsync(RetrieveImageUrl, filename);

                // Check for JSON indicating a failure
                try
                {
                    if (File.Exists(filename))
                    {
                        FileInfo FI = new FileInfo(filename);
                        if (FI.Length < 1024)
                        {
                            string FileContents = File.ReadAllText(filename);
                            BaseResponseModel BRM = JsonConvert.DeserializeObject<BaseResponseModel>(FileContents);
                            if (BRM.success != "yes")
                            {
                                throw new LNDException(BRM.error);
                            }
                        }
                    }
                }
                catch (LNDException)
                {
                    // Re-throw the LNDException so the caller knows the retrieve failed
                    throw;
                }
                catch
                {
                    // If it happened to be a REALLLLY small image (<1024 bytes), then DeserializeObject() will throw
                    // an exception.  The File.ReadAllText() could also throw an exception if the file happened to be
                    // locked by another process right after the download finished.
                    // We're going to ignore these types of exceptions, with the assumption that the image downloaded
                    // successfully
                }
            }
        }
    }
}

namespace lndapi.Image
{
    public class ImageRetrieveProgressChangedEventArgs : EventArgs
    {
        public long BytesReceived { get; set; }
        public long TotalBytesToReceive { get; set; }
        public double ProgressPercentage { get; set; }

        public ImageRetrieveProgressChangedEventArgs(long bytesReceived, long totalBytesToReceive)
        {
            this.BytesReceived = bytesReceived;
            this.TotalBytesToReceive = totalBytesToReceive;
            this.ProgressPercentage = (double)this.BytesReceived / (double)this.TotalBytesToReceive;
        }
    }
}
