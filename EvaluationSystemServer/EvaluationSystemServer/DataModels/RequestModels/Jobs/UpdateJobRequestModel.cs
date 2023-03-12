namespace EvaluationSystemServer
{
    public class UpdateJobRequestModel : BaseRequestModel
    {
        #region Public Constructors

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
        public int Salary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateJobRequestModel() 
        { 
        
        }

        #endregion
    }

    public class CreateJobRequestModel : UpdateJobRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The company Id
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
}
