using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueByte.Common
{
    /// <summary>
    /// Callback interface.
    /// </summary>
    public interface ICallback
    {
        #region 

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;


        #endregion

        #region properties 

        /// <summary>
        /// Gets the cancellation request.
        /// </summary>
        /// <value>
        /// The cancellation request.
        /// </value>
        CancellationRequest CancellationRequest { get; }

        #region progress 
        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        /// <value>
        /// The current position.
        /// </value>
        int CurrentPosition { get; set; }

        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>
        /// The start position.
        /// </value>
        int StartPosition { get; set; }

        /// <summary>
        /// Gets or sets the end position.
        /// </summary>
        /// <value>
        /// The end position.
        /// </value>
        int EndPosition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inderterminate.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is inderterminate; otherwise, <c>false</c>.
        /// </value>
        bool IsInderterminate { get; set; }


        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        bool HasError { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }

        #endregion


        #region methods 

        /// <summary>
        /// Cancels the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Cancel(string message);
        /// <summary>
        /// Cancels this instance.
        /// </summary>
        void Cancel();
        /// <summary>
        /// Finishes the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        void Finish(string error = null);
        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();

        #endregion 

    }
}
