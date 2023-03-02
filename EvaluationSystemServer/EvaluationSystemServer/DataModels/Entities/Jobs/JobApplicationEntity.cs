using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobApplicationEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The employee
        public UserEntity Employee { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The manager
        public UserEntity Manager { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int EvaluatorId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The evaluator
        public UserEntity Evaluator { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobPositionEntity"/>
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobApplicationEntity"/>
        /// </summary>
        /// The job position
        public JobPositionEntity JobPosition { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobApplicationEntity() 
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="JobApplicationEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="employeeId">The employee's id</param>
        /// <param name="evaluatorId">The evaluator's id</param>
        /// <param name="managerId">The manager's id</param>
        /// <param name="jobPositionId">The job position's id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JobApplicationEntity FromRequestModel(int employeeId, int managerId, int evaluatorId, int jobPositionId, JobApplicationRequestModel model)
            => ControllerHelpers.FromRequestModel(model, (JobApplicationEntity entity) => { entity.EmployeeId = employeeId; entity.EvaluatorId = evaluatorId; entity.ManagerId = managerId; entity.JobPositionId = jobPositionId; });

        /// <summary>
        /// Creates and returns a <see cref="JobApplicationResponseModel"/> from the current <see cref="JobApplicationEntity"/>
        /// </summary>
        /// <returns></returns>
        public JobApplicationResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<JobApplicationEntity, JobApplicationResponseModel>(this);

        #endregion
    }
}
