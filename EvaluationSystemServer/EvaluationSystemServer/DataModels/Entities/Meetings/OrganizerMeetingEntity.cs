namespace EvaluationSystemServer
{
    public class OrganizerMeetingEntity : BaseEntity
    {

        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int OrganizerId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity Organizer { get; set; }

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

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public OrganizerMeetingEntity() 
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="OrganizerMeetingResponseModel"/> from the current <see cref="OrganizerMeetingEntity"/>
        /// </summary>
        /// <returns></returns>
        public OrganizerMeetingResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<OrganizerMeetingEntity, OrganizerMeetingResponseModel>(this);

        #endregion
    }
}
