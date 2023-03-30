namespace EvaluationSystemServer
{
    public class MeetingRequestModel : BaseRequestModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeetingRequestModel() : base()
        {

        }

        #endregion
    }

    public class CreateMeetingRequestModel : MeetingRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The organizer's id
        /// </summary>
        public int OrganizerId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateMeetingRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateMeetingRequestModel : MeetingRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateMeetingRequestModel() : base()
        {

        }

        #endregion
    }
}
