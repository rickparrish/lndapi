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
        /// <summary>
        /// Retrieve an image (i.e. download an image to your computer)
        /// </summary>
        /// <param name="imageId">The id of the image to download</param>
        /// <param name="filename">The full path and filename to save the downloaded image as</param>
        /// <param name="progressEventHandler">The event handler to call with progress updates</param>
        public async Task ImageRetrieveAsync(int imageId, string filename, EventHandler<ImageRetrieveProgressChangedEventArgs> progressEventHandler)
        {
            var ImageDetails = await this.ImageDetailsAsync(imageId);

            using (NoKeepAlivesWebClient WC = new NoKeepAlivesWebClient())
            {
                WC.Proxy = null;
                if (progressEventHandler != null)
                {
                    WC.DownloadProgressChanged += (s, e) =>
                    {
                        progressEventHandler(s, new ImageRetrieveProgressChangedEventArgs(e.BytesReceived, e.TotalBytesToReceive > 0 ? e.TotalBytesToReceive : ImageDetails.size));
                    };
                }

                // TODO This should be moved to the base Request method and an IF could handle image/retrieve separately (with this code)
                //      Maybe a new RequestFile method could be added instead
                Uri RetrieveImageUrl = new Uri($"{BASE_URL_LEGACY}?category=image&action=retrieve&image_id={imageId}&api_id={_APIId}&api_key={_APIKey}");
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