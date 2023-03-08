namespace EvaluationSystemServer
{
    public class JobRequestModel : BaseRequestModel
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
        public JobRequestModel() 
        { 
        
        }

        #endregion
    }
}
