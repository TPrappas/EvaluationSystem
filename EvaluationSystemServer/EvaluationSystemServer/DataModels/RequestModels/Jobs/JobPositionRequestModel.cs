namespace EvaluationSystemServer
{
    public class JobPositionRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// Is the position open or closed
        /// </summary>
        public bool IsOpen { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionRequestModel() 
        { 
        
        }

        #endregion
    }

    public class CreateJobPositionRequestModel : JobPositionRequestModel 
    {
        #region Public Properties

        /// <summary>
        /// The job's id
        /// </summary>
        public int JobId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor 
        /// </summary>
        public CreateJobPositionRequestModel()
        {

        }

        #endregion
    }

    public class UpdateJobPositionRequestModel : JobPositionRequestModel
    {
        #region Public Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateJobPositionRequestModel()
        {

        }

        #endregion
    }
}
