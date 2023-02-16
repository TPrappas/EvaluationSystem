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
}
