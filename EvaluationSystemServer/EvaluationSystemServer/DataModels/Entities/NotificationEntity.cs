namespace EvaluationSystemServer
{
    public class NotificationEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The user
        public UserEntity? User { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotificationEntity() : base()
        {

        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Creates and returns a <see cref="NotificationEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static NotificationEntity FromRequestModel(NotificationRequestModel model)
            => ControllerHelpers.FromRequestModel<NotificationEntity, NotificationRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="NotificationResponseModel"/> from the current <see cref="NotificationEntity"/>
        /// </summary>
        /// <returns></returns>
        public NotificationResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<NotificationEntity, NotificationResponseModel>(this);


        #endregion
    }
}
