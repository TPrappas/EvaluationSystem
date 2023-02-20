﻿using Microsoft.AspNetCore.Mvc;
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
        /// Creates a new admin
        /// </summary>
        /// Post api/users
        [HttpPost]
        [Route(Routes.JobsRoute)]
        public Task<ActionResult<JobResponseModel>> CreateJobAsync([FromBody] JobRequestModel model)
            => ControllerHelpers.PostAsync<JobEntity, JobResponseModel>(
                mContext,
                mContext.Jobs,
                JobEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the admins from the database
        /// </summary>
        /// Get api/admins
        [HttpGet]
        [Route(Routes.JobsRoute)]
        public Task<ActionResult<IEnumerable<JobResponseModel>>> GetJobsAsync() =>
            // Gets the response models for each admin entity
            ControllerHelpers.GetAllAsync<JobEntity, JobResponseModel>(
                mContext.Jobs,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="adminId">The admins's id</param>
        /// Get api/admins/{adminId} == api/admins/1
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
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// <param name="model">The admin request model</param>
        /// Put /api/admins/{adminId}
        [HttpPut]
        [Route(Routes.JobRoute)]
        public Task<ActionResult<JobResponseModel>> UpdateJobAsync([FromRoute] int jobId, [FromBody] JobRequestModel model)
        {
            return ControllerHelpers.PutAsync<JobRequestModel, JobEntity, JobResponseModel>(
                mContext,
                mContext.Jobs,
                model,
                x => x.Id == jobId);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// Delete /api/admins/{adminId}
        [HttpDelete]
        [Route(Routes.AdminRoute)]
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
