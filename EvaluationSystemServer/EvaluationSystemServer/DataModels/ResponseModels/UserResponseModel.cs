namespace EvaluationSystemServer
{
    public class UserResponseModel : DateResponseModel
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

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The bio
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The recommendations
        /// </summary>
        public string Recommendations { get; set; }

        /// <summary>
        /// The rating
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// The user type
        /// </summary>
        public StaffType UserType { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedCompanyResponseModel"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public EmbeddedCompanyResponseModel Company { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionResponseModel"/>
        /// </summary>
        public JobPositionResponseModel JobPosition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor 
        /// </summary>
        public UserResponseModel() : base()
        {

        }

        #endregion

    }

    public class EmbeddedUserResponseModel : DateResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// The firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The rating
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedCompanyResponseModel"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public EmbeddedCompanyResponseModel Company { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionResponseModel"/>
        /// </summary>
        public JobPositionResponseModel JobPosition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedUserResponseModel() : base()
        { 
        
        }

        #endregion
    }
}
