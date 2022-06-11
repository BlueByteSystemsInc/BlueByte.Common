using System;

namespace BlueByte.Common
{
    /// <summary>
    /// Cancellation request class.
    /// </summary>
    public class CancellationRequest : IDisposable
    {

        /// <summary>
        /// Gets a value indicating whether this instance has been used to request a cancellation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cancellation requested; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancellationRequested { get; private set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        public CancellationRequest()
        {

        }

        /// <summary>
        /// Requests a cancellation.
        /// </summary>
        public void RequestCancellation()
        {
            if (IsDisposed)
                throw new Exception($"Cannot reuse this instance. You can only use {nameof(RequestCancellation)} once.");

            IsCancellationRequested = true;
            
            IsDisposed = true;
        }

        public void Dispose()
        {
            IsDisposed = true; 
        }
    }
}
