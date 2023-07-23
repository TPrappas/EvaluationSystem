namespace EvaluationSystemServer
{
    public class NotificationRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The notification type
        /// </summary>
        public NotificationType? NotificationType { get; set; }

        /// <summary>
        /// The message
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Is the notification read
        /// </summary>
        public bool? IsRead { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int? UserId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotificationRequestModel() : base()
        {

        }

        #endregion
    }
}
