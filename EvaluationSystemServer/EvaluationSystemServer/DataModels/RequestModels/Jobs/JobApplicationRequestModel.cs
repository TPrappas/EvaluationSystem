namespace EvaluationSystemServer
{
    public class JobApplicationRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double? Grade { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// The submission start
        /// </summary>
        public DateTimeOffset? SubmissionStart { get; set; }

        /// <summary>
        /// The submission end
        /// </summary>
        public DateTimeOffset? SubmissionEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateJobApplicationRequestModel : JobApplicationRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The manager's id
        /// </summary>
        public int? ManagerId { get; set; }

        /// <summary>
        /// The evaluator's id
        /// </summary>
        public int? EvaluatorId { get; set; }

        /// <summary>
        /// The employee's id
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// The job position's id
        /// </summary>
        public int? JobPositionId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateJobApplicationRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateJobApplicationRequestModel : JobApplicationRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateJobApplicationRequestModel() : base()
        {

        }

        #endregion
    }
}
