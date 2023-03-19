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
        public double? MinGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? MaxGrade { get; set; }


        /// <summary>
        /// After submission start
        /// </summary>
        public DateTimeOffset? AfterSubmissionStart { get; set; }

        /// <summary>
        /// Before submission start
        /// </summary>
        public DateTimeOffset? BeforeSubmissionStart { get; set; }

        /// <summary>
        /// After submission end
        /// </summary>
        public DateTimeOffset? AfterSubmissionEnd { get; set; }

        /// <summary>
        /// Before submission end
        /// </summary>
        public DateTimeOffset? BeforeSubmissionEnd { get; set; }

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
