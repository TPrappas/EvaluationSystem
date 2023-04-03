namespace EvaluationSystemServer
{
    public class MeetingArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="IncludeOrganizer"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeOrganizers;

        /// <summary>
        /// The member of the <see cref="ExcludeOrganizer"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeOrganizers;

        #endregion

        #region Public Properties

        /// <summary>
        /// Organizer included
        /// </summary>
        public IEnumerable<int> IncludeOrganizer 
        { 
            get => mIncludeOrganizers ?? Enumerable.Empty<int>();
            
            set => mIncludeOrganizers = value; 
        }

        /// <summary>
        /// Organizer excluded
        /// </summary>
        public IEnumerable<int> ExcludeOrganizer 
        { 
            get => mExcludeOrganizers ?? Enumerable.Empty<int>();
            
            set => mExcludeOrganizers = value;
        }

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
        public MeetingArgs()
        {

        }

        #endregion
    }
}
