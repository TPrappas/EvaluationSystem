using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class ProjectController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Projects
        /// </summary>
        protected IQueryable<ProjectEntity> ProjectsQuery => mContext.Projects.Include(x => x.User);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProjectController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// Post api/projects
        [HttpPost]
        [Route(Routes.ProjectsRoute)]
        public async Task<ActionResult<ProjectResponseModel>> CreateProjectAsync([FromBody] ProjectRequestModel model)
            => (await DI.GetProjectsManager.AddProjectAsync(model)).ToResponseModel();

        /// <summary>
        /// Gets all the projects from the database
        /// </summary>
        /// Get api/projects
        [HttpGet]
        [Route(Routes.ProjectsRoute)]
        public Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetProjectsAsync([FromQuery] ProjectArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<ProjectEntity, bool>>>();

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

            // If the included Users is not null...
            if (args.IncludeUsers is not null)
                // Add to filters
                filters.Add(x => args.IncludeUsers.Contains(x.UserId));

            // If the excluded Users is not null...
            if (args.ExcludeUsers is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeUsers.Contains(x.UserId));

            // Gets the response models for each project entity
            return ControllerHelpers.GetAllAsync<ProjectEntity, ProjectResponseModel>(
                ProjectsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the project with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// Get api/projects/{projectId} == api/projects/1
        [HttpGet]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> GetProjectAsync([FromRoute] int projectId)
        {
            // The needed expression for the filter
            Expression<Func<ProjectEntity, bool>> filter = x => x.Id == projectId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<ProjectEntity, ProjectResponseModel>(
                ProjectsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the project with the specified id
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// <param name="model">The project request model</param>
        /// Put /api/projects/{projectId}
        [HttpPut]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> UpdateProjectAsync([FromRoute] int projectId, [FromBody] ProjectRequestModel model)
        {
            return ControllerHelpers.PutAsync<ProjectRequestModel, ProjectEntity, ProjectResponseModel>(
                mContext,
                ProjectsQuery,
                model,
                x => x.Id == projectId);
        }

        /// <summary>
        /// Deletes the project with the specified id if exists from the database
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// Delete /api/projects/{projectId}
        [HttpDelete]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<ProjectResponseModel>> DeleteProjectAsync([FromRoute] int projectId)
        {
            return ControllerHelpers.DeleteAsync<ProjectEntity, ProjectResponseModel>(
                mContext,
                ProjectsQuery,
                DI.GetMapper,
                x => x.Id == projectId);
        }

        #endregion
    }
}
