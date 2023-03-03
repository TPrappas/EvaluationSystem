using EvaluationSystemServerngs;

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
        /// The meetings's participants
        /// </summary>
        public IEnumerable<OrganizerMeetingEntity> OrganizerMeetings { get; set; }

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
    }
}
