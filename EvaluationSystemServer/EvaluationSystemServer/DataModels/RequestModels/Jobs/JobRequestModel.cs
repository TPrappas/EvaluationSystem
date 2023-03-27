namespace EvaluationSystemServer
{
    public class JobRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateJobRequestModel : UpdateJobRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateJobRequestModel() : base()
        { 
        
        }

        #endregion
    }

    public class UpdateJobRequestModel : JobRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateJobRequestModel() : base()
        {

        }

        #endregion
    }
}
