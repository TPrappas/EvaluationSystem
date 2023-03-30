namespace EvaluationSystemServer
{
    public class AdminRequestModel : BaseRequestModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Username"/> property
        /// </summary>
        private string? mUsername;

        /// <summary>
        /// The member of the <see cref="Password"/> property
        /// </summary>
        private string? mPassword;

        #endregion

        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username
        {
            get => mUsername ?? string.Empty;

            set => mUsername = value;
        }

        /// <summary>
        /// The password
        /// </summary>
        public string Password
        {
            get => mPassword ?? string.Empty;

            set => mPassword = value;
        }

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
