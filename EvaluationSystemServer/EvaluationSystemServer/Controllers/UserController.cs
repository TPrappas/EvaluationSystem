using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class UserController : Controller
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
        public UserController(EvaluationSystemDBContext context) 
        { 
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// Post home/users
        [HttpPost]
        [Route(Routes.UsersRoute)]
        public Task<ActionResult<UserResponseModel>> CreateUserAsync([FromBody] int companyId, int jobPositionId, UserRequestModel model)
            => ControllerHelpers.PostAsync<UserEntity, UserResponseModel>(
                mContext,
                mContext.Users,
                UserEntity.FromRequestModel(companyId, jobPositionId, model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// Get home/users
        [HttpGet]
        [Route(Routes.UsersRoute)]
        public Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync() =>
            // Gets the response models for each user entity
            ControllerHelpers.GetAllAsync<UserEntity, UserResponseModel>(
                mContext.Users,
                x => true);

        /// <summary>
        /// Gets the user with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// Get home/users/{userId} == home/users/2
        [HttpGet]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> GetUserAsync([FromRoute] int userId)
        {
            // The needed expression for the filter
            Expression<Func<UserEntity, bool>> filter = x => x.Id == userId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<UserEntity, UserResponseModel>(
                mContext.Users,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="model">The user request model</param>
        /// Put /home/users/{userId}
        [HttpPut]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> UpdateUserAsync([FromRoute] int userId, [FromBody] UserRequestModel model)
        {
            return ControllerHelpers.PutAsync<UserRequestModel, UserEntity, UserResponseModel>(
                mContext,
                mContext.Users,
                model,
                x => x.Id == userId);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// Delete /home/users/{userId}
        [HttpDelete]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> DeleteUserAsync(int userId)
        {
            return ControllerHelpers.DeleteAsync<UserEntity, UserResponseModel>(
                mContext,
                mContext.Users,
                DI.GetMapper,
                x => x.Id == userId);
        }

        #endregion
    }
}
