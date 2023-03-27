using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobPositionEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Is the position open or closed
        /// </summary>
        public bool IsOpen { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobEntity"/>
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// The related <see cref="JobEntity"/>
        /// </summary>
        public JobEntity Job { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The job's position employees
        /// </summary>
        public IEnumerable<UserEntity> Employees { get; set; }

        /// <summary>
        /// The job's applications
        /// </summary>
        public IEnumerable<JobApplicationEntity> JobApplications { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobPositionEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="JobPositionEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="jobId">the job's id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JobPositionEntity FromRequestModel(CreateJobPositionRequestModel model)
            => ControllerHelpers.FromRequestModel<JobPositionEntity, CreateJobPositionRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="JobPositionResponseModel"/> from the current <see cref="JobPositionEntity"/>
        /// </summary>
        /// <returns></returns>
        public JobPositionResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<JobPositionEntity, JobPositionResponseModel>(this);

        #endregion

    }
}
