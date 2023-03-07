namespace EvaluationSystemServer
{
    public class MeetingResponseModel : BaseResponseModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeetingResponseModel()
        {

        }

        #endregion
    }

    public class EmbeddedMeetingResponseModel : BaseResponseModel 
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
        /// The location
        /// </summary>
        public string Location { get; set; }

        #endregion
    }
}
