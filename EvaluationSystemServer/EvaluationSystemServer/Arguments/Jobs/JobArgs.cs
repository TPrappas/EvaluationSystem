namespace EvaluationSystemServer
{
    public class JobArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        #endregion

        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search 
        { 
            get => mSearch ?? string.Empty;
            
            set => mSearch = value; 
        }

        /// <summary>
        /// By min salary
        /// </summary>
        public decimal? MinSalary { get; set; }

        /// <summary>
        /// By max salary
        /// </summary>
        public decimal? MaxSalary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobArgs()
        {

        }

        #endregion
    }
}
