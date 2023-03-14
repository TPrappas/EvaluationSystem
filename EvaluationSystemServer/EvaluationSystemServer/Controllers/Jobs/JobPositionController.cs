using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer.Controllers.Jobs
{
    public class JobPositionController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public JobPositionController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new job position
        /// </summary>
        /// Post api/jobPositions
        [HttpPost]
        [Route(Routes.JobPositionsRoute)]
        public Task<ActionResult<JobPositionResponseModel>> CreateJobPositionAsync([FromBody] CreateJobPositionRequestModel model)
            => ControllerHelpers.PostAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext,
                mContext.JobPositions,
                JobPositionEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the job positions from the database
        /// </summary>
        /// Get api/jobPositions
        [HttpGet]
        [Route(Routes.JobPositionsRoute)]
        public Task<ActionResult<IEnumerable<JobPositionResponseModel>>> GetJobPositionsAsync() =>
            // Gets the response models for each job position entity
            ControllerHelpers.GetAllAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext.JobPositions,
                x => true);

        /// <summary>
        /// Gets the job position with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="jobPositionId">The job position's id</param>
        /// Get api/jobPosition/{positionId} == api/jobPosition/1
        [HttpGet]
        [Route(Routes.JobPositionRoute)]
        public Task<ActionResult<JobPositionResponseModel>> GetJobPositionAsync([FromRoute] int jobPositionId)
        {
            // The needed expression for the filter
            Expression<Func<JobPositionEntity, bool>> filter = x => x.Id == jobPositionId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext.JobPositions,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the job position with the specified id
        /// </summary>
        /// <param name="jobPositionId">The job position's id</param>
        /// <param name="model">The job position request model</param>
        /// Put /api/jobPosition/{jobPositionId}
        [HttpPut]
        [Route(Routes.JobPositionRoute)]
        public Task<ActionResult<JobPositionResponseModel>> UpdateJobPositionAsync([FromRoute] int jobPositionId, [FromBody] JobPositionRequestModel model)
        {
            return ControllerHelpers.PutAsync<JobPositionRequestModel, JobPositionEntity, JobPositionResponseModel>(
                mContext,
                mContext.JobPositions,
                model,
                x => x.Id == jobPositionId);
        }

        /// <summary>
        /// Deletes the job position with the specified id if exists from the database
        /// </summary>
        /// <param name="jobPositionId">The job position's id</param>
        /// Delete /api/jobPositions/{jobPositionId}
        [HttpDelete]
        [Route(Routes.JobPositionRoute)]
        public Task<ActionResult<JobPositionResponseModel>> DeleteJobPositionAsync(int jobPositionId)
        {
            return ControllerHelpers.DeleteAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext,
                mContext.JobPositions,
                DI.GetMapper,
                x => x.Id == jobPositionId);
        }

        #endregion
    }
}
