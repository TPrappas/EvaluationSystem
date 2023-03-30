namespace EvaluationSystemServer
{
    public class MeetingEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        /// <summary>
        /// The member of the <see cref="Location"/> property
        /// </summary>
        private string? mDescription;

        #endregion

        #region Public Properties

        /// <summary>
        /// The date
        /// </summary>
        public DateTimeOffset MeetingDate { get; set; }

        /// <summary>
        /// The duration
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The link
        /// </summary>
        public Uri? Link { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title 
        { 
            get => mTitle ?? string.Empty;
            
            set => mTitle = value;
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description 
        { 
            get => mDescription ?? string.Empty;
           
            set => mDescription = value;
        }

        /// <summary>
        /// The location
        /// </summary>
        public string? Location { get; set; }

        #region Relationships

        /// <summary>
        /// The meetings's participants
        /// </summary>
        public IEnumerable<ParticipantMeetingEntity>? ParticipantMeetings { get; set; }

        /// <summary>
        /// The meetings's organizer
        /// </summary>
        public int OrganizerId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity? Organizer { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MeetingEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CreateMeetingRequestModel"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static MeetingEntity FromRequestModel(CreateMeetingRequestModel model)
            => ControllerHelpers.FromRequestModel<MeetingEntity, CreateMeetingRequestModel>(model);


        /// <summary>
        /// Creates and returns a <see cref="MeetingResponseModel"/> from the current <see cref="MeetingEntity"/>
        /// </summary>
        /// <returns></returns>
        public MeetingResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<MeetingEntity, MeetingResponseModel>(this);

        #endregion
    }
}
