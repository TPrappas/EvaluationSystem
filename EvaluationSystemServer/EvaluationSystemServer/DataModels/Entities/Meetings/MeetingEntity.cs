using System.Collections.ObjectModel;

namespace EvaluationSystemServer
{
    public class MeetingEntity : NormalizedEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Location"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="ParticipantMeetings"/> property
        /// </summary>
        private ICollection<ParticipantMeetingEntity>? mParticipantMeetings;

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
        public ICollection<ParticipantMeetingEntity>? ParticipantMeetings 
        {
            get => mParticipantMeetings ??= new Collection<ParticipantMeetingEntity>();
            
            set => mParticipantMeetings = value;
        }

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
        public static MeetingEntity FromRequestModel(MeetingRequestModel model)
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
