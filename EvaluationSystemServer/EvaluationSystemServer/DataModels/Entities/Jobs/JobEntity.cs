using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name 
        { 
            get => mName ?? string.Empty;
            
            set => mName = value; 
        }    

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
        public IEnumerable<JobPositionEntity>? JobPositions { get; set; }
 
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