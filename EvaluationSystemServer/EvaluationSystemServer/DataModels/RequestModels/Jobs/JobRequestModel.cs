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
        public JobRequestModel()
        {

        }

        #endregion

    }

    public class CreateJobRequestModel : UpdateJobRequestModel
    {
        #region Public Constructors

        /// <summary>
        /// The company id
        /// </summary>
        public int CompanyId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateJobRequestModel() 
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
        public UpdateJobRequestModel()
        {

        }

        #endregion
    }
}
