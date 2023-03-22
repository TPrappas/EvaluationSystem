using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class UserEntity : BaseEntity
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
        /// The first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
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
        /// The staff type 
        /// </summary>
        public StaffType UserType { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        /// The id of the related company
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobPositionEntity"/>
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionEntity"/>
        /// </summary>
        public JobPositionEntity JobPosition { get; set; }

        /// <summary>
        /// The user's skills
        /// </summary>
        public IEnumerable<UserSkillEntity> UserSkills { get; set; }

        /// <summary>
        /// The users's certificates
        /// </summary>
        public IEnumerable<UserCertificateEntity> UserCertificates { get; set; }

        /// <summary>
        /// The user's projects
        /// </summary>
        public IEnumerable<ProjectEntity> Projects { get; set; }

        #region Applications

        /// <summary>
        /// The employee's application
        /// </summary>
        public IEnumerable<JobApplicationEntity> EmployeeApplications { get; set; }

        /// <summary>
        /// The manager's application
        /// </summary>
        public IEnumerable<JobApplicationEntity> ManagerApplications { get; set; }

        /// <summary>
        /// The evaluator's application
        /// </summary>
        public IEnumerable<JobApplicationEntity> EvaluatorApplications { get; set; }

        #endregion

        #region Meetings

        /// <summary>
        /// The participants's meetings
        /// </summary>
        public IEnumerable<ParticipantMeetingEntity> ParticipantsMeeting { get; set; }

        /// <summary>
        /// The organizer's meetings
        /// </summary>
        public IEnumerable<MeetingEntity> OrganizersMeeting { get; set; }

        #endregion

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="UserEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserEntity FromRequestModel(UserRequestModel model)
            => ControllerHelpers.FromRequestModel<UserEntity, UserRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="UserResponseModel"/> from the current <see cref="UserEntity"/>
        /// </summary>
        /// <returns></returns>
        public UserResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<UserEntity, UserResponseModel>(this);

        #endregion
    }
}
