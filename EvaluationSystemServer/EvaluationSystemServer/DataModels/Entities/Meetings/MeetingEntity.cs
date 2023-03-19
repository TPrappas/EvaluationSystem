namespace EvaluationSystemServer
{
    public class MeetingEntity : BaseEntity
    {
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
        public string Link { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The location
        /// </summary>
        public string Location { get; set; }

        #region Relationships

        /// <summary>
        /// The meetings's participants
        /// </summary>
        public IEnumerable<ParticipantMeetingEntity> ParticipantMeetings { get; set; }

        /// <summary>
        /// The meetings's organizer
        /// </summary>
        //public int OrganizerId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
       // public UserEntity Organizer { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MeetingEntity()
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
            => ControllerHelpers.FromRequestModel<MeetingEntity, MeetingRequestModel>(model);


        /// <summary>
        /// Creates and returns a <see cref="MeetingResponseModel"/> from the current <see cref="MeetingEntity"/>
        /// </summary>
        /// <returns></returns>
        public MeetingResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<MeetingEntity, MeetingResponseModel>(this);

        #endregion
    }
}
