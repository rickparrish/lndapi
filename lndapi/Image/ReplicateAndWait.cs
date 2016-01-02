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
    // TODO This code is mostly duplicated in VMSnapshotAndWait
    public partial class LNDynamic
    {
        /// <summary>
        /// Replicate an image to a new region and wait for it to become active
        /// </summary>
        /// <param name="imageId">The id of the image to replicate</param>
        /// <param name="region">The region to replicate the image to</param>
        /// <param name="queuedEventHandler">The event handler to call when the image creation is first queued</param>
        /// <param name="waitingEventHandler">The event handler to call when the image is queued or saving</param>
        /// <param name="retryingEventHandler">The event handler to call when the image creation fails and needs to be retried</param>
        /// <returns>The id for the newly created image</returns>
        public async Task<int> ImageReplicateAndWaitAsync(int imageId, string region, EventHandler<ImageQueuedEventArgs> queuedEventHandler, EventHandler<ImageWaitingEventArgs> waitingEventHandler, EventHandler<ImageRetryingEventArgs> retryingEventHandler)
        {
            int RetryCount = 0;
            Retry:

            // Replicate the image
            var NewImageId = await ImageReplicateAsync(imageId, region);

            // Notify that the image has been queued
            if (queuedEventHandler != null) queuedEventHandler(this, new ImageQueuedEventArgs(NewImageId));

            // Wait for new image to be 'active'
            try
            {
                string NewImageStatus = (await ImageDetailsAsync(NewImageId)).status;
                while (NewImageStatus != "active")
                {
                    // Check for killed image
                    if (NewImageStatus == "killed") throw new LNDImageKilledException("image status=killed");

                    // Notify that the image is not yet active
                    if (waitingEventHandler != null) waitingEventHandler(this, new ImageWaitingEventArgs(NewImageId, NewImageStatus));

                    // Wait for 30 seconds then re-check the status
                    // TODO Make 30 configurable
                    Thread.Sleep(30000);
                    NewImageStatus = (await ImageDetailsAsync(NewImageId)).status;
                }
            }
            catch (LNDImageKilledException)
            {
                // Delete the killed image
                await ImageDeleteAsync(NewImageId);

                // Retry if we're within our limit
                // TODO Make 3 configurable
                if (RetryCount++ < 3)
                {
                    // Notify that the image creation failed and needs to retry
                    if (retryingEventHandler != null) retryingEventHandler(this, new ImageRetryingEventArgs(NewImageId, RetryCount, 3));

                    // Wait for 30 seconds then re-check the status
                    Thread.Sleep(30000);
                    goto Retry;
                }

                // No retries left, throw the exception
                throw;
            }

            return NewImageId;
        }
    }
}