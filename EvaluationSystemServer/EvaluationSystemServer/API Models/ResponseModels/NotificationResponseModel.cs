namespace EvaluationSystemServer
{
    public class NotificationResponseModel : DateResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Message"/> property
        /// </summary>
        public string? mMessage { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The notification type
        /// </summary>
        public NotificationType NotificationType { get; set; }

        /// <summary>
        /// The message
        /// </summary>
        public string Message
        {
            get => mMessage ?? string.Empty;

            set => mMessage = value;
        }

        /// <summary>
        /// Is the notification read
        /// </summary>
        public bool IsRead { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotificationResponseModel() : base()
        {

        }

        #endregion

    }
}
