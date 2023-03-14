namespace EvaluationSystemServer
{
    public class JobApplicationRequestModel : BaseRequestModel
    {

        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The submission start
        /// </summary>
        public DateTimeOffset SubmissionStart { get; set; }

        /// <summary>
        /// The submission end
        /// </summary>
        public DateTimeOffset SubmissionEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationRequestModel()
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
        public int ManagerId { get; set; }

        /// <summary>
        /// The evaluator's id
        /// </summary>
        public int EvaluatorId { get; set; }

        /// <summary>
        /// The employee's id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The job's id
        /// </summary>
        public int JobId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateJobApplicationRequestModel()
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
        public UpdateJobApplicationRequestModel()
        {

        }

        #endregion
    }
}
