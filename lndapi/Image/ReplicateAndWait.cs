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
        /// Replicate an image to a new region and wait for it to become active
        /// </summary>
        /// <param name="imageId">The id of the image to replicate</param>
        /// <param name="region">The region to replicate the image to</param>
        /// <param name="queuedEventHandler">The event handler to call when the image creation is first queued</param>
        /// <param name="waitingEventHandler">The event handler to call when the image is queued or saving</param>
        /// <param name="retryingEventHandler">The event handler to call when the image creation fails and needs to be retried</param>
        /// <returns>The id for the newly created image</returns>
        public async Task<int> ImageReplicateAndWaitAsync(int imageId, string region, int waitSeconds, int maxRetries, EventHandler<ImageQueuedEventArgs> queuedEventHandler, EventHandler<ImageStatusEventArgs> statusEventHandler, EventHandler<ImageRetryingEventArgs> retryingEventHandler)
        {
            // Replicate the image
            var NewImageId = await ImageReplicateAsync(imageId, region);

            // Notify that the replication has been queued
            if (queuedEventHandler != null) queuedEventHandler(this, new ImageQueuedEventArgs(NewImageId));

            // Wait for the image to become active
            await ImageWaitForActive(NewImageId, waitSeconds, maxRetries, statusEventHandler, async (s, e) =>
            {
                // Notify that a retry is taking place
                retryingEventHandler(s, e);

                // Replicate again
                NewImageId = await ImageReplicateAsync(imageId, region);

                // Notify that the snapshot has been queued
                if (queuedEventHandler != null) queuedEventHandler(this, new ImageQueuedEventArgs(NewImageId));

                // Tell event raiser what the new image id is
                e.NewImageId = NewImageId;
            });

            return NewImageId;
        }
    }
}