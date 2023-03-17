using Microsoft.AspNetCore.Mvc;
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
        public Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetProjectsAsync() =>
            // Gets the response models for each project entity
            ControllerHelpers.GetAllAsync<ProjectEntity, ProjectResponseModel>(
                mContext.Projects,
                x => true);

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
                mContext.Projects,
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
                mContext.Projects,
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
        public Task<ActionResult<ProjectResponseModel>> DeleteProjectAsync(int projectId)
        {
            return ControllerHelpers.DeleteAsync<ProjectEntity, ProjectResponseModel>(
                mContext,
                mContext.Projects,
                DI.GetMapper,
                x => x.Id == projectId);
        }

        #endregion
    }
}
