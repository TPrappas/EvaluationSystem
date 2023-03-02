using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer.Controllers.Jobs
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
        /// Creates a new job application
        /// </summary>
        /// Post api/jobApplications
        [HttpPost]
        [Route(Routes.JobApplicationsRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> CreateJobApplicationAsync([FromBody] int employeeId, int managerId, int evaluatorId, int jobPositionId, JobApplicationRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.JobApplications,
                JobApplicationEntity.FromRequestModel(employeeId, managerId, evaluatorId, jobPositionId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the job applications from the database
        /// </summary>
        /// Get api/jobApplications
        [HttpGet]
        [Route(Routes.JobApplicationsRoute)]
        public Task<ActionResult<IEnumerable<JobApplicationResponseModel>>> GetJobApplicationsAsync() =>
            // Gets the response models for each job application entity
            ControllerHelpers.GetAllAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext.JobApplications,
                x => true);

        /// <summary>
        /// Gets the job application with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="jobApplicationId">The job application's id</param>
        /// Get api/jobApplications/{adminId} == api/jobApplications/1
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
        /// Updates the job application with the specified id
        /// </summary>
        /// <param name="jobApplcationId">The job application's id</param>
        /// <param name="model">The job application request model</param>
        /// Put /api/jobApplications/{jobApplicationId}
        [HttpPut]
        [Route(Routes.JobApplicationRoute)]
        public Task<ActionResult<JobApplicationResponseModel>> UpdateJobApplcationAsync([FromRoute] int jobApplcationId, [FromBody] JobApplicationRequestModel model)
        {
            return ControllerHelpers.PutAsync<JobApplicationRequestModel, JobApplicationEntity, JobApplicationResponseModel>(
                mContext,
                mContext.JobApplications,
                model,
                x => x.Id == jobApplcationId);
        }

        /// <summary>
        /// Deletes the job application with the specified id if exists from the database
        /// </summary>
        /// <param name="jobApplicationId">The job application's id</param>
        /// Delete /api/jobApplications/{jobApplicationId}
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
