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
}
