namespace EvaluationSystemServer
{
    public class JobApplicationArgs : BaseArgs
    {
        #region Public Methods

        /// <summary>
        /// Manager included
        /// </summary>
        public IEnumerable<int> IncludeManagers { get; set; }

        /// <summary>
        /// Manager excluded
        /// </summary>
        public IEnumerable<int> ExcludeManagers { get; set; }

        /// <summary>
        /// Evaluator included
        /// </summary>
        public IEnumerable<int> IncludeEvaluators { get; set; }

        /// <summary>
        /// Evaluator excluded
        /// </summary>
        public IEnumerable<int> ExcludeEvaluators { get; set; }

        /// <summary>
        /// Employee included
        /// </summary>
        public IEnumerable<int> IncludeEmployees { get; set; }

        /// <summary>
        /// Employee excluded
        /// </summary>
        public IEnumerable<int> ExcludeEmployees { get; set; }

        /// <summary>
        /// By minGrade
        /// </summary>
        public double? minGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? maxGrade { get; set; }


        /// <summary>
        /// By submission start
        /// </summary>
        public DateTimeOffset? SubmissionStart { get; set; }

        /// <summary>
        /// By submission end
        /// </summary>
        public DateTimeOffset? SubmissionEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationArgs()
        {

        }

        #endregion

    }
}
