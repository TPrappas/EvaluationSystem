using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class JobApplicationController : Controller
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
        public JobApplicationController(EvaluationSystemDBContext context)
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
        [Route(Routes.JobApplicationsRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> CreateJobApplicationAsync([FromBody] int userId, int jobPositionId, JobApplicationRequestModel model)
            => ControllerHelpers.PostAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext,
                mContext.JobApplications,
                JobApplicationEntity.FromRequestModel(userId, jobPositionId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the admins from the database
        /// </summary>
        /// Get api/admins
        [HttpGet]
        [Route(Routes.JobApplicationsRoute)]
        public Task<ActionResult<IEnumerable<JobApplicationResponseModel>>> GetJobApplicationsAsync() =>
            // Gets the response models for each admin entity
            ControllerHelpers.GetAllAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext.JobApplications,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="adminId">The admins's id</param>
        /// Get api/admins/{adminId} == api/admins/1
        [HttpGet]
        [Route(Routes.JobApplicationRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> GetJobApplicationAsync([FromRoute] int jobApplicationId)
        {
            // The needed expression for the filter
            Expression<Func<JobApplicationEntity, bool>> filter = x => x.Id == jobApplicationId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext.JobApplications,
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
        [Route(Routes.JobApplicationRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> UpdateJobApplcationAsync([FromRoute] int jobApplcationId, [FromBody] AdminRequestModel model)
        {
            return ControllerHelpers.PutAsync<JobApplicationRequestModel, JobApplicationEntity, JobApplicationResponseModel>(
                mContext,
                mContext.JobApplications,
                model,
                x => x.Id == jobApplcationId);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// Delete /api/admins/{adminId}
        [HttpDelete]
        [Route(Routes.JobApplicationRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> DeleteJobApplicationAsync(int jobApplicationId)
        {
            return ControllerHelpers.DeleteAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext,
                mContext.JobApplications,
                DI.GetMapper,
                x => x.Id == jobApplicationId);
        }

        #endregion
    }
}
