using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace EvaluationSystemServer.Controllers.Jobs
{
    public class JobController : Controller
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
        public JobController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new job
        /// </summary>
        /// Post api/jobs
        [HttpPost]
        [Route(Routes.JobsRoute)]
        public Task<ActionResult<JobResponseModel>> CreateJobAsync([FromBody] CreateJobRequestModel model)
            => ControllerHelpers.PostAsync<JobEntity, JobResponseModel>(
                mContext,
                mContext.Jobs,
                JobEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the jobs from the database
        /// </summary>
        /// Get api/jobs
        [HttpGet]
        [Route(Routes.JobsRoute)]
        public Task<ActionResult<IEnumerable<JobResponseModel>>> GetJobsAsync([FromQuery] JobArgs args)
        {
            var filters = new List<Expression<Func<JobEntity, bool>>>();

            if (!string.IsNullOrEmpty(args.Search))
                filters.Add(x => x.Name.Contains(args.Search));

            if (args.AfterDateCreated is not null)
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            if (args.BeforeDateCreated is not null)
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);  

            if (args.MinSalary is not null)
                filters.Add(x => args.MinSalary >= x.Salary);

            if (args.MaxSalary is not null)
                filters.Add(x => args.MaxSalary <= x.Salary);

            if (args.IncludeCompanies is not null)
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            if (args.ExcludeCompanies is not null)
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            // Gets the response models for each job entity
            return ControllerHelpers.GetAllAsync<JobEntity, JobResponseModel>(
                mContext.Jobs.Include(x => x.Company).Include(x => x.JobPositions),
                args,
                filters);
        }

        /// <summary>
        /// Gets the job with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="jobId">The job's id</param>
        /// Get api/jobs/{jobId} == api/jobs/1
        [HttpGet]
        [Route(Routes.JobRoute)]
        public Task<ActionResult<JobResponseModel>> GetJobAsync([FromRoute] int jobId)
        {
            // The needed expression for the filter
            Expression<Func<JobEntity, bool>> filter = x => x.Id == jobId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<JobEntity, JobResponseModel>(
                mContext.Jobs,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the job with the specified id
        /// </summary>
        /// <param name="jobId">The job's id</param>
        /// <param name="model">The job request model</param>
        /// Put /api/jobs/{adminId}
        [HttpPut]
        [Route(Routes.JobRoute)]
        public Task<ActionResult<JobResponseModel>> UpdateJobAsync([FromRoute] int jobId, [FromBody] UpdateJobRequestModel model)
        {
            return ControllerHelpers.PutAsync<UpdateJobRequestModel, JobEntity, JobResponseModel>(
                mContext,
                mContext.Jobs,
                model,
                x => x.Id == jobId);
        }

        /// <summary>
        /// Deletes the job with the specified id if exists from the database
        /// </summary>
        /// <param name="jobId">The job's id</param>
        /// Delete /api/jobs/{jobId}
        [HttpDelete]
        [Route(Routes.JobRoute)]
        public Task<ActionResult<JobResponseModel>> DeleteJobAsync(int jobId)
        {
            return ControllerHelpers.DeleteAsync<JobEntity, JobResponseModel>(
                mContext,
                mContext.Jobs,
                DI.GetMapper,
                x => x.Id == jobId);
        }

        #endregion
    }
}
