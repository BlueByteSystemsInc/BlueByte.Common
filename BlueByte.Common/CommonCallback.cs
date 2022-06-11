using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlueByte.Common
{
    /// <summary>
    /// Common implementation <see cref="ICallback"/>.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="BlueByte.Common.ICallback" />
    public class CommonCallback : INotifyPropertyChanged, ICallback
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region properties 


        private bool isInderterminate;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inderterminate.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is inderterminate; otherwise, <c>false</c>.
        /// </value>
        public bool IsInderterminate
        {
            get { return isInderterminate; }
            set
            {
                hasError = value;
                NotifyPropertyChanged(nameof(isInderterminate));
            }
        }

        private bool hasError;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get { return hasError; }
            set {
                hasError = value;
                NotifyPropertyChanged(nameof(HasError)); }
        }

        private string message;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }


        private int startPosition;

        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>
        /// The start position.
        /// </value>
        public int StartPosition
        {
            get { return startPosition; }
            set
            {
                StartPosition = value;
                NotifyPropertyChanged(nameof(StartPosition));  }
        }

        private int endPosition;
        /// <summary>
        /// Gets or sets the end position.
        /// </summary>
        /// <value>
        /// The end position.
        /// </value>
        public int EndPosition
        {
            get { return endPosition; }
            set
            {
                EndPosition = value;
                NotifyPropertyChanged(nameof(EndPosition));
            }
        }

        private int currentPosition;
        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        /// <value>
        /// The current position.
        /// </value>
        public int CurrentPosition
        {
            get { return currentPosition; }
            set
            {
                CurrentPosition = value;
                NotifyPropertyChanged(nameof(CurrentPosition));
            }
        }


        public CancellationRequest CancellationRequest { get; private set; }

        #endregion

        /// <summary>
        /// Throws <see cref="CancellationException"/>.
        /// </summary>
        /// <exception cref="BlueByte.Common.CancellationException"></exception>
        public void Cancel()
        {
            throw new CancellationException();
        }


        /// <summary>
        /// Throws <see cref="CancellationException"/>.
        /// </summary>
        public void Cancel(string message)
        {
            throw new CancellationException(message);
        }

        /// <summary>
        /// Throws <see cref="CancellationException"/>.
        /// </summary>
        public void Cancel(string message, Exception innerExeption)
        {
            throw new CancellationException(message, innerExeption);
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="CommonCallback"/> class.
        /// </summary>
        /// <remarks>This constructor initializes <see cref="CancellationRequest"/></remarks>
        public CommonCallback()
        {

            CancellationRequest = new CancellationRequest();
        }

        /// <summary>
        /// Sets the progress properties to final values.
        /// </summary>
        /// <param name="error">The error.</param>
        public void Finish(string error = null)
        {

            CurrentPosition = EndPosition;
            if (string.IsNullOrWhiteSpace(error) == false)
            {
                HasError = true;
                Message = error;
            }
            else
                Message = $"Completed.";
        }



        /// <summary>
        /// Flushes the instance. Use this method to reuse the instance for a new set of files.
        /// </summary>
        /// <param name="error">The error.</param>
        public void Flush()
        {
            Message = string.Empty;
            EndPosition = int.MaxValue;
            CurrentPosition = 0;
            StartPosition = 0;
            CancellationRequest = new CancellationRequest();
            HasError = false;
        }

    }
}
