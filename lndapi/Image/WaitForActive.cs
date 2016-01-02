using lndapi.Base;
using lndapi.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        /// <summary>
        /// Wait for an image to become active
        /// </summary>
        /// <param name="imageId">The id of the VM to wait for to become active</param>
        /// <param name="waitSeconds">The number of seconds to wait in between status checks (10-60)</param>
        /// <param name="maxRetries">The maximum number of retries when image creation fails</param>
        /// <param name="queuedEventHandler">The event handler to call when the image creation is first queued</param>
        /// <param name="statusEventHandler">The event handler to call when the image is queued or saving</param>
        /// <param name="retryingEventHandler">The event handler to call when the image creation fails and needs to be retried</param>
        /// <returns>The id for the newly created image</returns>
        public async Task ImageWaitForActive(int imageId, int waitSeconds, int maxRetries, EventHandler<ImageStatusEventArgs> statusEventHandler, EventHandler<ImageRetryingEventArgs> retryingEventHandler)
        {
            // Enforce sane wait values
            if (waitSeconds > 60) waitSeconds = 60;
            if (waitSeconds < 10) waitSeconds = 10;

            // Ensure we have a retry handler if we're allowing retries
            if ((maxRetries > 0) && (retryingEventHandler == null)) {
                throw new ArgumentNullException("retryingEventHandler", "retryingEventHandler cannot be null when maxRetries > 0");
            }

            int RetryCount = 0;
            Retry:

            // Wait for new image to be 'active'
            try
            {
                string ImageStatus = (await ImageDetailsAsync(imageId)).status;
                while (ImageStatus != "active")
                {
                    // Notify that the image is not yet active
                    if (statusEventHandler != null) statusEventHandler(this, new ImageStatusEventArgs(imageId, ImageStatus, waitSeconds));

                    // Check for killed image
                    if (ImageStatus == "killed") throw new LNDImageKilledException("image status=killed");

                    // Wait then re-check the status
                    Thread.Sleep(waitSeconds * 1000);
                    ImageStatus = (await ImageDetailsAsync(imageId)).status;
                }
            }
            catch (LNDImageKilledException)
            {
                // Delete the killed image
                await ImageDeleteAsync(imageId);

                // Retry if we're within our limit
                if (RetryCount++ < maxRetries)
                {
                    Thread.Sleep(waitSeconds * 1000);

                    // Notify that the image creation failed and needs to retry
                    var REA = new ImageRetryingEventArgs(imageId, RetryCount, maxRetries, waitSeconds);
                    retryingEventHandler(this, REA);
                    if (REA.NewImageId > 0)
                    {
                        imageId = REA.NewImageId;
                    }
                    else
                    {
                        throw new ArgumentNullException("NewImageId", "NewImageId must be set with the new image id to monitor");
                    }

                    goto Retry;
                }

                // No retries left, throw the exception
                throw;
            }
        }
    }
}