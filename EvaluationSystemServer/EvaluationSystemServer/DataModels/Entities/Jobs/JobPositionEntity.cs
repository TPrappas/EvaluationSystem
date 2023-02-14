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

    }
}
