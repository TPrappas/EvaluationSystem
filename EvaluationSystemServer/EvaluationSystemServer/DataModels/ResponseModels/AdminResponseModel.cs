namespace EvaluationSystemServer
{
    public class AdminResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminResponseModel() 
        { 
        
        }

        #endregion

    }
}
