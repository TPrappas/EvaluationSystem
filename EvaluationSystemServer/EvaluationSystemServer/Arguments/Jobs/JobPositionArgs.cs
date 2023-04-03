namespace EvaluationSystemServer.Arguments.Jobs
{
    public class JobPositionArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="IncludeJobs"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeJobs;

        /// <summary>
        /// The member of the <see cref="ExcludeJobs"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeJobs;

        /// <summary>
        /// The member of the <see cref="IncludeCompanies"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeCompanies;

        /// <summary>
        /// The member of the <see cref="ExcludeCompanies"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeCompanies;

        #endregion

        #region Public Properties

        /// <summary>
        /// Job included
        /// </summary>
        public IEnumerable<int> IncludeJobs 
        { 
            get => mIncludeJobs ?? Enumerable.Empty<int>();
            
            set => mIncludeJobs = value; 
        }

        /// <summary>
        /// Job excluded
        /// </summary>
        public IEnumerable<int> ExcludeJobs 
        {
            get => mExcludeJobs ?? Enumerable.Empty<int>();
            
            set => mExcludeJobs = value;
        }

        /// <summary>
        /// By isOpen
        /// </summary>
        public bool? isOpen { get; set; }

        /// <summary>
        /// Company included
        /// </summary>
        public IEnumerable<int> IncludeCompanies 
        {
            get => mIncludeCompanies ?? Enumerable.Empty<int>(); 
            
            set => mIncludeCompanies = value;
        }

        /// <summary>
        /// Company excluded
        /// </summary>
        public IEnumerable<int> ExcludeCompanies 
        {
            get => mExcludeCompanies ?? Enumerable.Empty<int>();
            
            set => mExcludeCompanies = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionArgs()
        {

        }

        #endregion
    }
}
