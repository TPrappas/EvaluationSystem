using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }    

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// The job's positions
        /// </summary>
        public IEnumerable<JobPositionEntity> JobPositions { get; set; }
 
        #endregion

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public JobEntity() : base()
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="JobEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JobEntity FromRequestModel(CreateJobRequestModel model)
            => ControllerHelpers.FromRequestModel<JobEntity, CreateJobRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="JobResponseModel"/> from the current <see cref="JobEntity"/>
        /// </summary>
        /// <returns></returns>
        public JobResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<JobEntity, JobResponseModel>(this);

        #endregion

    }
}