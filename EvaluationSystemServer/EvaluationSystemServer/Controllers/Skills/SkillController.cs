using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class SkillController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Skills
        /// </summary>
        protected IQueryable<SkillEntity> SkillsQuery => mContext.Skills;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public SkillController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new skill
        /// </summary>
        /// Post api/skills
        [HttpPost]
        [Route(Routes.SkillsRoute)]
        public Task<ActionResult<SkillResponseModel>> CreateSkillAsync([FromBody] SkillRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Skills,
                SkillEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the skills from the database
        /// </summary>
        /// Get api/skills
        [HttpGet]
        [Route(Routes.SkillsRoute)]
        public Task<ActionResult<IEnumerable<SkillResponseModel>>> GetSkillsAsync([FromQuery] SkillArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<SkillEntity, bool>>>();

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

            // Gets the response models for each skill entity
            return ControllerHelpers.GetAllAsync<SkillEntity, SkillResponseModel>(
                SkillsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the skill with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="skillId">The skills's id</param>
        /// Get api/skills/{skillId} == api/skills/1
        [HttpGet]
        [Route(Routes.SkillRoute)]
        public Task<ActionResult<SkillResponseModel>> GetSkillAsync([FromRoute] int skillId)
        {
            // The needed expression for the filter
            Expression<Func<SkillEntity, bool>> filter = x => x.Id == skillId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<SkillEntity, SkillResponseModel>(
                SkillsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the skill with the specified id
        /// </summary>
        /// <param name="skillId">The skills's id</param>
        /// <param name="model">The skill request model</param>
        /// Put /api/skill/{skillId}
        [HttpPut]
        [Route(Routes.SkillRoute)]
        public Task<ActionResult<SkillResponseModel>> UpdateSkillAsync([FromRoute] int skillId, [FromBody] SkillRequestModel model)
        {
            return ControllerHelpers.PutAsync<SkillRequestModel, SkillEntity, SkillResponseModel>(
                mContext,
                SkillsQuery,
                model,
                x => x.Id == skillId);
        }

        /// <summary>
        /// Deletes the skill with the specified id if exists from the database
        /// </summary>
        /// <param name="skillId">The skill's id</param>
        /// Delete /api/skills/{skillId}
        [HttpDelete]
        [Route(Routes.SkillRoute)]
        public Task<ActionResult<SkillResponseModel>> DeleteSkillAsync([FromRoute] int skillId)
        {
            return ControllerHelpers.DeleteAsync<SkillEntity, SkillResponseModel>(
                mContext,
                SkillsQuery,
                DI.GetMapper,
                x => x.Id == skillId);
        }

        #endregion
    }
}
