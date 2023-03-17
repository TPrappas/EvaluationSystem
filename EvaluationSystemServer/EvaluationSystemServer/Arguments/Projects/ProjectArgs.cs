namespace EvaluationSystemServer
{
    public class ProjectArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By minGrade
        /// </summary>
        public double? minGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? maxGrade { get; set; }

        /// <summary>
        /// Is the project submitted
        /// </summary>
        public bool isSubmitted { get; set; }

        /// <summary>
        /// By submission start
        /// </summary>
        public DateTimeOffset? SubmissionStart { get; set; }

        /// <summary>
        /// By submission end
        /// </summary>
        public DateTimeOffset? SubmissionEnd { get; set; }

        /// <summary>
        /// User included
        /// </summary>
        public IEnumerable<int> IncludeUsers { get; set; }

        /// <summary>
        /// User excluded
        /// </summary>
        public IEnumerable<int> ExcludeUsers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectArgs()
        {

        }

        #endregion
    }
}
