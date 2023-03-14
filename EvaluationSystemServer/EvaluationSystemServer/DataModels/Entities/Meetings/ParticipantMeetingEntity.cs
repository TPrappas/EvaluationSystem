using EvaluationSystemServer;

namespace EvaluationSystemServer
{
    public class ParticipantMeetingEntity : BaseEntity
    {

        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity Participant { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="MeetingEntity"/>
        /// </summary>
        public int MeetingId { get; set; }

        /// <summary>
        /// The related <see cref="MeetingEntity"/>
        /// </summary>
        public MeetingEntity Meeting { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ParticipantMeetingEntity() 
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ParticipantMeetingResponseModel"/> from the current <see cref="ParticipantMeetingEntity"/>
        /// </summary>
        /// <returns></returns>
        public ParticipantMeetingResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<ParticipantMeetingEntity, ParticipantMeetingResponseModel>(this);

        #endregion
    }
}
