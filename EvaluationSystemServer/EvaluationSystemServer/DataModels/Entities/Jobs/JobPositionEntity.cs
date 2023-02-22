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
        /// Is the position open or closed
        /// </summary>
        public bool IsOpen { get; set; }

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
        public JobPositionEntity()
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
        public static JobPositionEntity FromRequestModel(int jobId, JobPositionRequestModel model)
            => ControllerHelpers.FromRequestModel(model, (JobPositionEntity entity) => { entity.JobId = jobId; });

        /// <summary>
        /// Creates and returns a <see cref="JobPositionResponseModel"/> from the current <see cref="JobPositionEntity"/>
        /// </summary>
        /// <returns></returns>
        public JobPositionResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<JobPositionEntity, JobPositionResponseModel>(this);

        #endregion

    }
}
