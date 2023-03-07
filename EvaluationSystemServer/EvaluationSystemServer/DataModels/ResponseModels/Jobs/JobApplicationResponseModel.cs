namespace EvaluationSystemServer
{
    public class JobApplicationResponseModel : BaseResponseModel
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

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The employee
        public EmbeddedUserResponseModel User { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionResponseModel"/>
        /// </summary>
        public JobPositionResponseModel JobPosition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationResponseModel()
        {

        }

        #endregion

    }
}
