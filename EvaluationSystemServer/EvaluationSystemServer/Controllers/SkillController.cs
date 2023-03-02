using EvaluationSystemServer.DataModels.Entities.Skills;
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
            => ControllerHelpers.PostAsync<SkillEntity, SkillResponseModel>(
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
        public Task<ActionResult<IEnumerable<SkillResponseModel>>> GetSkillsAsync() =>
            // Gets the response models for each skill entity
            ControllerHelpers.GetAllAsync<SkillEntity, SkillResponseModel>(
                mContext.Skills,
                x => true);

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
                mContext.Skills,
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
                mContext.Skills,
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
        public Task<ActionResult<SkillResponseModel>> DeleteSkillAsync(int skillId)
        {
            return ControllerHelpers.DeleteAsync<SkillEntity, SkillResponseModel>(
                mContext,
                mContext.Skills,
                DI.GetMapper,
                x => x.Id == skillId);
        }

        #endregion
    }
}
