using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class AdminController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Admins
        /// </summary>
        protected IQueryable<AdminEntity> AdminsQuery => mContext.Admins;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public AdminController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new admin
        /// </summary>
        /// Post api/admins
        [HttpPost]
        [Route(Routes.AdminsRoute)]
        public Task<ActionResult<AdminResponseModel>> CreateAdminAsync([FromBody] AdminRequestModel model)
            => ControllerHelpers.PostAsync<AdminEntity, AdminResponseModel>(
                mContext,
                mContext.Admins,
                AdminEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the admins from the database
        /// </summary>
        /// Get api/admins
        [HttpGet]
        [Route(Routes.AdminsRoute)]
        public Task<ActionResult<IEnumerable<EmbeddedAdminResponseModel>>> GetAdminsAsync([FromQuery] AdminArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<AdminEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Username.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the After Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // Gets the response models for each admin entity
            return ControllerHelpers.GetAllAsync<AdminEntity, EmbeddedAdminResponseModel>(
                AdminsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the admin with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="adminId">The admins's id</param>
        /// Get api/admins/{adminId} == api/admins/1
        [HttpGet]
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<EmbeddedAdminResponseModel>> GetAdminAsync([FromRoute] int adminId)
        {
            // The needed expression for the filter
            Expression<Func<AdminEntity, bool>> filter = x => x.Id == adminId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<AdminEntity, EmbeddedAdminResponseModel>(
                AdminsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the admin with the specified id
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// <param name="model">The admin request model</param>
        /// Put /api/admins/{adminId}
        [HttpPut]
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<AdminResponseModel>> UpdateAdminAsync([FromRoute] int adminId, [FromBody] AdminRequestModel model)
        {
            return ControllerHelpers.PutAsync<AdminRequestModel, AdminEntity, AdminResponseModel>(
                mContext,
                AdminsQuery,
                model,
                x => x.Id == adminId);
        }

        /// <summary>
        /// Deletes the admin with the specified id if exists from the database
        /// </summary>
        /// <param name="adminId">The admin's id</param>
        /// Delete /api/admins/{adminId}
        [HttpDelete]
        [Route(Routes.AdminRoute)]
        public Task<ActionResult<AdminResponseModel>> DeleteAdminAsync([FromRoute] int adminId)
        {
            return ControllerHelpers.DeleteAsync<AdminEntity, AdminResponseModel>(
                mContext,
                AdminsQuery,
                DI.GetMapper,
                x => x.Id == adminId);
        }

        #endregion
    }
}
