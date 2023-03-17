namespace EvaluationSystemServer
{
    public class MeetingArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// Organizer included
        /// </summary>
        public IEnumerable<int> IncludeOrganizer { get; set; }

        /// <summary>
        /// Organizer excluded
        /// </summary>
        public IEnumerable<int> ExcludeOrganizer { get; set; }

        /// <summary>
        /// By date
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// By min duration
        /// </summary>
        public TimeSpan? minDuration { get; set; }

        /// <summary>
        /// By max duration
        /// </summary>
        public TimeSpan? maxDuration { get; set; }

        /// <summary>
        /// By name
        /// </summary>
        public string Search { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeetingArgs()
        {

        }

        #endregion
    }
}
