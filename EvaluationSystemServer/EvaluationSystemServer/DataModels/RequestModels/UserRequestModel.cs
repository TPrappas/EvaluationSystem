namespace EvaluationSystemServer
{
    public class UserRequestModel : BaseRequestModel
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

        /// <summary>
        /// The member of the <see cref="Email"/> property
        /// </summary>
        private string? mEmail;

        /// <summary>
        /// The member of the <see cref="FirstName"/> property
        /// </summary>
        private string? mFirstName;

        /// <summary>
        /// The member of the <see cref="LastName"/> property
        /// </summary>
        private string? mLastName;

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

        /// <summary>
        /// The email
        /// </summary>
        public string Email
        {
            get => mEmail ?? string.Empty;

            set => mEmail = value;
        }

        /// <summary>
        /// The first name
        /// </summary>
        public string FirstName
        {
            get => mFirstName ?? string.Empty;

            set => mFirstName = value;
        }

        /// <summary>
        /// The last name
        /// </summary>
        public string LastName
        {
            get => mLastName ?? string.Empty;

            set => mLastName = value;
        }

        /// <summary>
        /// The bio
        /// </summary>
        public string? Bio { get; set; }

        /// <summary>
        /// The recommendations
        /// </summary>
        public string? Recommendations { get; set; }

        /// <summary>
        /// The rating
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// The company' id
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The job position's id
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The user type
        /// </summary>
        public StaffType UserType { get; set; }

        /// <summary>
        /// The certificate's id
        /// </summary>
        public IEnumerable<int>? Certificates { get; set; }

        /// <summary>
        /// The skill's id
        /// </summary>
        public IEnumerable<int>? Skills { get; set; }

        /// <summary>
        /// The participant meeting's id
        /// </summary>
        public IEnumerable<int>? ParticipantMeetings { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserRequestModel() : base()
        {

        }

        #endregion
    }

    public class CreateUserRequestModel : UserRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateUserRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateUserRequestModel : UserRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateUserRequestModel() : base()
        {

        }

        #endregion
    }
}
