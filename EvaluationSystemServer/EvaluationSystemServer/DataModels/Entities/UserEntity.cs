// Ignore Spelling: Username Bio

using Bogus.DataSets;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class UserEntity : BaseEntity
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

        /// <summary>
        /// The member of the <see cref="UserSkills"/> property
        /// </summary>
        private ICollection<UserSkillEntity>? mUserSkills;

        /// <summary>
        /// The member of the <see cref="UserCertificates"/> property
        /// </summary>
        private ICollection<UserCertificateEntity>? mUserCertificates;

        /// <summary>
        /// The member of the <see cref="Projects"/> property
        /// </summary>
        private ICollection<ProjectEntity>? mProjects;

        /// <summary>
        /// The member of the <see cref="EmployeeApplications"/> property
        /// </summary>
        private ICollection<JobApplicationEntity>? mEmployeeApplications;

        /// <summary>
        /// The member of the <see cref="ManagerApplications"/> property
        /// </summary>
        private ICollection<JobApplicationEntity>? mManagerApplications;

        /// <summary>
        /// The member of the <see cref="EvaluatorApplications"/> property
        /// </summaryJobApplicationEntity
        private ICollection<JobApplicationEntity>? mEvaluatorApplications;

        /// <summary>
        /// The member of the <see cref="ParticipantsMeeting"/> property
        /// </summaryJobApplicationEntity
        private ICollection<ParticipantMeetingEntity>? mParticipantsMeeting;

        /// <summary>
        /// The member of the <see cref="OrganizersMeeting"/> property
        /// </summaryJobApplicationEntity
        private ICollection<MeetingEntity>? mOrganizersMeeting;

        /// <summary>
        /// The member of the <see cref="Notifications"/> property
        /// 
        /// </summary>
        private ICollection<NotificationEntity>? mNotifications;

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
        /// The normalized <see cref="Name"/>
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
        public CompanyEntity? Company { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobPositionEntity"/>
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionEntity"/>
        /// </summary>
        public JobPositionEntity? JobPosition { get; set; }

        /// <summary>
        /// The user's skills
        /// </summary>
        public ICollection<UserSkillEntity> UserSkills 
        { 
            get => mUserSkills ??= new Collection<UserSkillEntity>(); 
            
            set => mUserSkills = value;
        }

        /// <summary>
        /// The users's certificates
        /// </summary>
        public ICollection<UserCertificateEntity> UserCertificates
        { 
            get => mUserCertificates ??= new Collection<UserCertificateEntity>(); 
            
            set => mUserCertificates = value;
        }

        /// <summary>
        /// The user's projects
        /// </summary>
        public ICollection<ProjectEntity> Projects 
        { 
            get => mProjects ??= new Collection<ProjectEntity>();
            
            set => mProjects = value;
        }

        public ICollection<NotificationEntity> Notifications 
        {
            get => mNotifications ??= new Collection<NotificationEntity>(); 
            
            set => mNotifications = value;
        }

        #region Applications

        /// <summary>
        /// The employee's application
        /// </summary>
        public ICollection<JobApplicationEntity> EmployeeApplications 
        { 
            get => mEmployeeApplications ??= new Collection<JobApplicationEntity>();
            
            set => mEmployeeApplications = value;
        }

        /// <summary>
        /// The manager's application
        /// </summary>
        public ICollection<JobApplicationEntity> ManagerApplications 
        { 
            get => mManagerApplications ??= new Collection<JobApplicationEntity>();
            
            set => mManagerApplications = value;
        }

        /// <summary>
        /// The evaluator's application
        /// </summary>
        public ICollection<JobApplicationEntity> EvaluatorApplications 
        { 
            get => mEvaluatorApplications ??= new Collection<JobApplicationEntity>(); 
            
            set => mEvaluatorApplications = value;
        }

        #endregion

        #region Meetings

        /// <summary>
        /// The participants's meetings
        /// </summary>
        public ICollection<ParticipantMeetingEntity> ParticipantsMeeting 
        { 
            get => mParticipantsMeeting ??= new Collection<ParticipantMeetingEntity>(); 
            
            set => mParticipantsMeeting = value; 
        }

        /// <summary>
        /// The organizer's meetings
        /// </summary>
        public ICollection<MeetingEntity> OrganizersMeeting 
        { 
            get => mOrganizersMeeting ??= new Collection<MeetingEntity>(); 
            
            set => mOrganizersMeeting = value;
        }

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
