﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class JobController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Jobs
        /// </summary>
        protected IQueryable<JobEntity> JobsQuery => mContext.Jobs.Include(x => x.JobPositions);

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
        public Task<ActionResult<JobResponseModel>> CreateJobAsync([FromBody] JobRequestModel model)
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
            // The list of the filters
            var filters = new List<Expression<Func<JobEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Name.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the min Salary is not null...
            if (args.MinSalary is not null)
                // Add to filters
                filters.Add(x => args.MinSalary >= x.Salary);

            // If the max Salary is not null...
            if (args.MaxSalary is not null)
                // Add to filters
                filters.Add(x => args.MaxSalary <= x.Salary);

            // Gets the response models for each job entity
            return ControllerHelpers.GetAllAsync<JobEntity, JobResponseModel>(
                JobsQuery,
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
                JobsQuery,
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
        public Task<ActionResult<JobResponseModel>> UpdateJobAsync([FromRoute] int jobId, [FromBody] JobRequestModel model)
        {
            return ControllerHelpers.PutAsync<JobRequestModel, JobEntity, JobResponseModel>(
                mContext,
                JobsQuery,
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
        public Task<ActionResult<JobResponseModel>> DeleteJobAsync([FromRoute] int jobId)
        {
            return ControllerHelpers.DeleteAsync<JobEntity, JobResponseModel>(
                mContext,
                JobsQuery,
                DI.GetMapper,
                x => x.Id == jobId);
        }

        #endregion
    }
}
