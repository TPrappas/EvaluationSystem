using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the users 
        /// </summary>
        protected IQueryable<UserEntity> UsersQuery => mContext.Users.Include(x => x.Company).Include(x => x.JobPosition);

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
        public async Task<ActionResult<UserResponseModel>> CreateUserAsync([FromBody] UserRequestModel model)
            => (await DI.GetUsersManager.AddUserAsync(model)).ToResponseModel();

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// Get home/users
        [HttpGet]
        [Route(Routes.UsersRoute)]
        public Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync([FromQuery] UserArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<UserEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Username.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If FirstName is not null...
            if (!string.IsNullOrEmpty(args.FirstName))
                // Add to filters
                filters.Add(x => x.FirstName.Contains(args.FirstName));

            // If LastName is not null...
            if (!string.IsNullOrEmpty(args.LastName))
                // Add to filters
                filters.Add(x => x.LastName.Contains(args.LastName));

            // If the Min Rating is not null...
            if (args.MinRating is not null)
                // Add to filters
                filters.Add(x => args.MinRating >= x.Rating);

            // If the Max Rating is not null...
            if (args.MaxRating is not null)
                // Add to filters
                filters.Add(x => args.MaxRating <= x.Rating);

            // If the UserType is not null...
            if (args.UserType is not null)
                // Add to filters
                filters.Add(x => args.UserType == x.UserType);

            // If the included Companies is not null...
            if (args.IncludeCompanies is not null)
                // Add to filters
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            // If the excluded Companies is not null...
            if (args.ExcludeCompanies is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            // If the included Job Positions is not null...
            if (args.IncludeJobPositions is not null)
                // Add to filters
                filters.Add(x => args.IncludeJobPositions.Contains(x.JobPositionId));

            // If the excluded Job Positions is not null...
            if (args.ExcludeJobPositions is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeJobPositions.Contains(x.JobPositionId));

            // Gets the response models for each user entity
            return ControllerHelpers.GetAllAsync<UserEntity, UserResponseModel>(
                UsersQuery,
                args,
                filters);
        }

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
                UsersQuery,
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
        public async Task<ActionResult<UserResponseModel>> UpdateUserAsync([FromRoute] int userId, [FromBody] UserRequestModel model)
        {
            return (await DI.GetUsersManager.UpdateUserAsync(userId, model)).ToResponseModel();
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// Delete /home/users/{userId}
        [HttpDelete]
        [Route(Routes.UserRoute)]
        public Task<ActionResult<UserResponseModel>> DeleteUserAsync([FromRoute] int userId)
        {
            return ControllerHelpers.DeleteAsync<UserEntity, UserResponseModel>(
                mContext,
                UsersQuery,
                DI.GetMapper,
                x => x.Id == userId);
        }

        #endregion
    }
}
