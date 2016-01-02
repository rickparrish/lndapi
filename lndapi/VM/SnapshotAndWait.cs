using lndapi.Base;
using lndapi.Image;
using lndapi.VM;
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
        /// Snapshot a VM and wait for it to become active (i.e. create an image of the VM)
        /// </summary>
        /// <param name="vmId">The id of the VM to snapshot</param>
        /// <param name="name">The name to give the snapshot</param>
        /// <param name="queuedEventHandler">The event handler to call when the image creation is first queued</param>
        /// <param name="statusEventHandler">The event handler to call when the image is queued or saving</param>
        /// <param name="retryingEventHandler">The event handler to call when the image creation fails and needs to be retried</param>
        /// <returns>The id for the newly created image</returns>
        public async Task<int> VMSnapshotAndWaitAsync(int vmId, string name, int waitSeconds, int maxRetries, EventHandler<ImageQueuedEventArgs> queuedEventHandler, EventHandler<ImageStatusEventArgs> statusEventHandler, EventHandler<ImageRetryingEventArgs> retryingEventHandler)
        {
            // Take the snapshot
            var NewImageId = await VMSnapshotAsync(vmId, name);

            // Notify that the snapshot has been queued
            if (queuedEventHandler != null) queuedEventHandler(this, new ImageQueuedEventArgs(NewImageId));

            // Wait for the snapshot to become active
            await ImageWaitForActive(NewImageId, waitSeconds, maxRetries, statusEventHandler, async (s, e) =>
            {
                // Notify that a retry is taking place
                retryingEventHandler(s, e);

                // Take a new snapshot
                NewImageId = await VMSnapshotAsync(vmId, name);

                // Notify that the snapshot has been queued
                if (queuedEventHandler != null) queuedEventHandler(this, new ImageQueuedEventArgs(NewImageId));

                // Tell event raiser what the new image id is
                e.NewImageId = NewImageId;
            });

            return NewImageId;
        }
    }
}