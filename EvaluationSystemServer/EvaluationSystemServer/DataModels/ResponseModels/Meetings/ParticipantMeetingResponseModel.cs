namespace EvaluationSystemServer
{
    public class ParticipantMeetingResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel Participant { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedMeetingResponseModel"/>
        /// </summary>
        public EmbeddedMeetingResponseModel Meeting { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ParticipantMeetingResponseModel()
        {

        }

        #endregion
    }

    public class EmbeddedParticipantMeetingResponseModel : ParticipantMeetingResponseModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedParticipantMeetingResponseModel() : base()
        {

        }

        #endregion
    }
}
