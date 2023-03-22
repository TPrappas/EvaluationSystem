using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Job Applications
        /// </summary>
        protected IQueryable<JobApplicationEntity> JobApplicationsQuery => mContext.JobApplications.Include(x => x.Manager).Include(x => x.Employee).Include(x => x.Evaluator).Include(x => x.JobPosition);

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
        public Task<ActionResult<JobApplicationResponseModel>> CreateJobApplicationAsync([FromBody] CreateJobApplicationRequestModel model)
            => ControllerHelpers.PostAsync<JobApplicationEntity, JobApplicationResponseModel>(
                mContext,
                mContext.JobApplications,
                JobApplicationEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the job applications from the database
        /// </summary>
        /// Get api/jobApplications
        [HttpGet]
        [Route(Routes.JobApplicationsRoute)]
        public Task<ActionResult<IEnumerable<JobApplicationResponseModel>>> GetJobApplicationsAsync([FromQuery] JobApplicationArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<JobApplicationEntity, bool>>>();

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the Min Grade is not null...
            if (args.MinGrade is not null)
                // Add to filters
                filters.Add(x => args.MinGrade >= x.Grade);

            // If the Min Grade is not null...
            if (args.MaxGrade is not null)
                // Add to filters
                filters.Add(x => args.MaxGrade <= x.Grade);

            // If the After Submission Start is not null...
            if (args.AfterSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart >= args.AfterSubmissionStart);

            // If the Before Submission Start is not null...
            if (args.BeforeSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart <= args.BeforeSubmissionStart);

            // If the After Submission End is not null...
            if (args.AfterSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd >= args.AfterSubmissionEnd);

            // If the Before Submission End is not null...
            if (args.BeforeSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd <= args.BeforeSubmissionEnd);

            // If the included Employees is not null...
            if (args.IncludeEmployees is not null)
                // Add to filters
                filters.Add(x => args.IncludeEmployees.Contains(x.EmployeeId));

            // If the excluded Employees is not null...
            if (args.ExcludeEmployees is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeEmployees.Contains(x.EmployeeId));

            // If the included Evaluator is not null...
            if (args.IncludeEvaluators is not null)
                // Add to filters
                filters.Add(x => args.IncludeEvaluators.Contains(x.EvaluatorId));

            // If the excluded Evaluator is not null...
            if (args.ExcludeEvaluators is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeEvaluators.Contains(x.EvaluatorId));

            // If the included Manager is not null...
            if (args.IncludeManagers is not null)
                // Add to filters
                filters.Add(x => args.IncludeEvaluators.Contains(x.ManagerId));

            // If the excluded Manager is not null...
            if (args.ExcludeManagers is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeManagers.Contains(x.ManagerId));

            // Gets the response models for each job application entity
            return ControllerHelpers.GetAllAsync<JobApplicationEntity, JobApplicationResponseModel>(
                JobApplicationsQuery,
                args,
                filters);
        }

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
                JobApplicationsQuery,
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
                JobApplicationsQuery,
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
                JobApplicationsQuery,
                DI.GetMapper,
                x => x.Id == jobApplicationId);
        }

        #endregion
    }
}
