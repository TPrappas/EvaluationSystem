using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class UserSkillController : Controller
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
        public UserSkillController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new userskill
        /// </summary>
        /// Post api/userSkills
        [HttpPost]
        [Route(Routes.UserSkillsRoute)]
        public Task<ActionResult<UserSkillResponseModel>> CreateUserSkillAsync([FromBody] UserSkillRequestModel model)
            => ControllerHelpers.PostAsync<UserSkillEntity, UserSkillResponseModel>(
                mContext,
                mContext.UserSkills,
                UserSkillEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the admins from the database
        /// </summary>
        /// Get api/admins
        [HttpGet]
        [Route(Routes.AdminsRoute)]
        public Task<ActionResult<IEnumerable<AdminResponseModel>>> GetAdminsAsync() =>
            // Gets the response models for each admin entity
            ControllerHelpers.GetAllAsync<AdminEntity, AdminResponseModel>(
                mContext.Admins,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="adminId">The admins's id</param>
        /// Get api/admins/{adminId} == api/admins/1
        [HttpGet]
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<AdminResponseModel>> GetAdminAsync([FromRoute] int adminId)
        {
            // The needed expression for the filter
            Expression<Func<AdminEntity, bool>> filter = x => x.Id == adminId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<AdminEntity, AdminResponseModel>(
                mContext.Admins,
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
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<AdminResponseModel>> UpdateUserAsync([FromRoute] int adminId, [FromBody] AdminRequestModel model)
        {
            return ControllerHelpers.PutAsync<AdminRequestModel, AdminEntity, AdminResponseModel>(
                mContext,
                mContext.Admins,
                model,
                x => x.Id == adminId);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// Delete /api/admins/{adminId}
        [HttpDelete]
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<AdminResponseModel>> DeleteUserAsync(int adminId)
        {
            return ControllerHelpers.DeleteAsync<AdminEntity, AdminResponseModel>(
                mContext,
                mContext.Admins,
                DI.GetMapper,
                x => x.Id == adminId);
        }

        #endregion
    }
}
