namespace EvaluationSystemServer
{
    public class AdminResponseModel : DateResponseModel
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
        /// The normalized <see cref="Username"/>
        /// </summary>
        public string NormalizedName
        {
            get => ControllerHelpers.NormalizeString(Username);

            set { }
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
        public AdminResponseModel() : base()
        { 
        
        }

        #endregion

    }

    public class EmbeddedAdminResponseModel : DateResponseModel 
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Username"/> property
        /// </summary>
        private string? mUsername;

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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedAdminResponseModel() : base()
        {

        }

        #endregion
    }
}
