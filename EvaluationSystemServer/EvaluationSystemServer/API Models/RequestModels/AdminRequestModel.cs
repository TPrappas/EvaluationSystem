namespace EvaluationSystemServer
{
    public class AdminRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        public string? Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminRequestModel() : base()
        {

        }

        #endregion
    }

    public class CreateAdminRequestModel : AdminRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateAdminRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateAdminRequestModel : AdminRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateAdminRequestModel() : base()
        {

        }

        #endregion
    }
}
