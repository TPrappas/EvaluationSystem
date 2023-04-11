namespace EvaluationSystemServer
{
    public class MeetingArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        #endregion

        #region Public Properties

        /// <summary>
        /// Organizer included
        /// </summary>
        public IEnumerable<int>? IncludeOrganizer { get; set; }

        /// <summary>
        /// Organizer excluded
        /// </summary>
        public IEnumerable<int>? ExcludeOrganizer { get; set; }
        /// <summary>
        /// By after date
        /// </summary>
        public DateTimeOffset? AfterDate { get; set; }

        /// <summary>
        /// By before date
        /// </summary>
        public DateTimeOffset? BeforeDate { get; set; }

        /// <summary>
        /// By min duration
        /// </summary>
        public TimeSpan? MinDuration { get; set; }

        /// <summary>
        /// By max duration
        /// </summary>
        public TimeSpan? MaxDuration { get; set; }

        /// <summary>
        /// By name
        /// </summary>
        public string Search
        {
            get => mSearch ?? string.Empty;

            set => mSearch = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeetingArgs() : base()
        {

        }

        #endregion
    }
}
