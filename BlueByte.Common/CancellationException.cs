using System;

namespace BlueByte.Common
{
    /// <summary>
    /// Cancellation exception 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CancellationException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationException"/> class.
        /// </summary>
        public CancellationException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public CancellationException(string message, Exception exception = null) : base(message, exception)
        {
            
        }
    } 
}
