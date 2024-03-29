﻿namespace EvaluationSystemServer
{
    public class UserRequestModel : BaseRequestModel
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

        /// <summary>
        /// The email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        public string? LastName { get; set; }

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
        public int? CompanyId { get; set; }

        /// <summary>
        /// The job position's id
        /// </summary>
        public int? JobPositionId { get; set; }

        /// <summary>
        /// The user type
        /// </summary>
        public StaffType? UserType { get; set; }

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
