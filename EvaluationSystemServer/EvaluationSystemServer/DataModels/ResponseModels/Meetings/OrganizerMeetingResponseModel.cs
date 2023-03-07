namespace EvaluationSystemServer
{
    public class OrganizerMeetingResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel Organizer { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedMeetingResponseModel"/>
        /// </summary>
        public EmbeddedMeetingResponseModel Meeting { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public OrganizerMeetingResponseModel()
        {

        }

        #endregion
    }
}
