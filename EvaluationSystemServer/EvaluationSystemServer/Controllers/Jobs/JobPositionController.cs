using EvaluationSystemServer.Arguments.Jobs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
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
        public Task<ActionResult<IEnumerable<JobPositionResponseModel>>> GetJobPositionsAsync([FromQuery] JobPositionArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<JobPositionEntity, bool>>>();

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the is Open is not null...
            if (args.isOpen is not null)
                // Add to filters
                filters.Add(x => args.isOpen == x.IsOpen);

            // If the included Jobs is not null...
            if (args.IncludeJobs is not null)
                // Add to filters
                filters.Add(x => args.IncludeJobs.Contains(x.JobId));

            // If the excluded Jobs is not null...
            if (args.ExcludeJobs is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeJobs.Contains(x.JobId));

            // Gets the response models for each job position entity
            return ControllerHelpers.GetAllAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext.JobPositions,
                args,
                filters);
        }

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
