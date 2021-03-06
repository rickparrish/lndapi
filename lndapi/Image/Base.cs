﻿using lndapi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi.Image
{
    /// <summary>
    /// Base request model that most Image API calls use
    /// </summary>
    public class ImageBaseRequestModel : BaseRequestModel
    {
        public int image_id { get; set; }

        public ImageBaseRequestModel(int imageId)
        {
            this.image_id = imageId;
        }
    }

    public class ImageQueuedEventArgs : EventArgs
    {
        public long ImageId { get; set; }

        public ImageQueuedEventArgs(int imageId)
        {
            this.ImageId = imageId;
        }
    }

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

    public class ImageRetryingEventArgs : EventArgs
    {
        public long ImageId { get; set; }
        public int MaxRetries { get; set; }
        public int RetryNumber { get; set; }
        public int WaitSeconds { get; set; }
        public int NewImageId { get; set; }

        public ImageRetryingEventArgs(int imageId, int retryNumber, int maxRetries, int waitSeconds)
        {
            this.ImageId = imageId;
            this.RetryNumber = retryNumber;
            this.MaxRetries = maxRetries;
            this.WaitSeconds = waitSeconds;
            this.NewImageId = -1;
        }
    }

    public class ImageStatusEventArgs : EventArgs
    {
        public long ImageId { get; set; }
        public string Status { get; set; }
        public int WaitSeconds { get; set; }

        public ImageStatusEventArgs(int imageId, string status, int waitSeconds)
        {
            this.ImageId = imageId;
            this.Status = status;
            this.WaitSeconds = waitSeconds;
        }
    }
}
