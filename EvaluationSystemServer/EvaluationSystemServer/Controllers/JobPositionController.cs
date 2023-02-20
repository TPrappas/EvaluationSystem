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
        /// Creates a new admin
        /// </summary>
        /// Post api/users
        [HttpPost]
        [Route(Routes.JobPositionRoute)]
        public Task<ActionResult<JobPositionResponseModel>> CreateJobPositionAsync([FromBody] JobPositionRequestModel model)
            => ControllerHelpers.PostAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext,
                mContext.JobPositions,
                AdminEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the admins from the database
        /// </summary>
        /// Get api/admins
        [HttpGet]
        [Route(Routes.JobPositionsRoute)]
        public Task<ActionResult<IEnumerable<JobPositionResponseModel>>> GetJobPositionsAsync() =>
            // Gets the response models for each admin entity
            ControllerHelpers.GetAllAsync<JobPositionEntity, JobPositionResponseModel>(
                mContext.JobPositions,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="adminId">The admins's id</param>
        /// Get api/admins/{adminId} == api/admins/1
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
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// <param name="model">The admin request model</param>
        /// Put /api/admins/{adminId}
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
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// Delete /api/admins/{adminId}
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
