using lndapi.Base;
using lndapi.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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
        /// <remarks>Requires the API Key to have LEGACY access enabled</remarks>
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

                Uri RetrieveImageUrl = new Uri($"{BASE_URL_LEGACY}?category=image&action=retrieve&image_id={imageId}&api_id={_APIId}&api_key={_APIKey}");
                await WC.DownloadFileTaskAsync(RetrieveImageUrl, filename);

                // TODOX Final progressEventHandler() call would be good, but how to know how many bytes were received/expected?
                //       Without final call program displays - Downloaded 28,180,193,280 of 28,182,839,296 bytes (99.99 %)...

                // Check for JSON indicating a failure
                try
                {
                    if (File.Exists(filename))
                    {
                        FileInfo FI = new FileInfo(filename);
                        if (FI.Length < 1024)
                        {
                            string FileContents = File.ReadAllText(filename);
                            BaseResponseModel BRM = (new JavaScriptSerializer()).Deserialize<BaseResponseModel>(FileContents);
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