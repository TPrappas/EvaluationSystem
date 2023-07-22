using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobEntity : NormalizedEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="JobPositions"/> property
        /// </summary>
        private ICollection<JobPositionEntity>? mJobPositions;

        #endregion

        #region Public Properties

        /// <summary>
        /// The description
        /// </summary>
        public string Description
        { 
            get => mDescription ?? string.Empty;
            
            set => mDescription = value;
        }

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #region Relationships

        /// <summary>
        /// The job's positions
        /// </summary>
        public ICollection<JobPositionEntity> JobPositions
        {
            get => mJobPositions ??= new Collection<JobPositionEntity>();
            
            set => mJobPositions = value;
        }
 
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
        public static JobEntity FromRequestModel(JobRequestModel model)
            => ControllerHelpers.FromRequestModel<JobEntity, JobRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="JobResponseModel"/> from the current <see cref="JobEntity"/>
        /// </summary>
        /// <returns></returns>
        public JobResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<JobEntity, JobResponseModel>(this);

        #endregion

    }
}