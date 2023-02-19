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
        /// The employee's application
        /// </summary>
        public IEnumerable<JobApplicationEntity> Applications { get; set; }    

        /// <summary>
        /// The employee's projects
        /// </summary>
        public IEnumerable<ProjectEntity> EmployeeProjects { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserEntity()
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="UserEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="jobPositionId">The job position's id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserEntity FromRequestModel(int companyId, int jobPositionId, UserRequestModel model) 
            => ControllerHelpers.FromRequestModel(model, (UserEntity entity) => { entity.CompanyId = companyId; entity.JobPositionId = jobPositionId; });

        /// <summary>
        /// Creates and returns a <see cref="UserResponseModel"/> from the current <see cref="UserEntity"/>
        /// </summary>
        /// <returns></returns>
        public UserResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<UserEntity, UserResponseModel>(this);

        #endregion
    }
}
