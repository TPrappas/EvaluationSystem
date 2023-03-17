namespace EvaluationSystemServer.Arguments.Jobs
{
    public class JobPositionArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// Job included
        /// </summary>
        public IEnumerable<int> IncludeJobs { get; set; }

        /// <summary>
        /// Job excluded
        /// </summary>
        public IEnumerable<int> ExcludeJobs { get; set; }

        /// <summary>
        /// By isOpen
        /// </summary>
        public bool isOpen { get; set; }


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
