using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class LicenseController : Controller
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
        protected IQueryable<LicenseEntity> LicensesQuery => mContext.Licenses.Include(x => x.Company);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public LicenseController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new license
        /// </summary>
        /// Post home/licenses
        [HttpPost]
        [Route(Routes.LicensesRoute)]
        public Task<ActionResult<LicenseResponseModel>> CreateLicenseAsync([FromBody] LicenseRequestModel model)
            => ControllerHelpers.PostAsync<LicenseEntity, LicenseResponseModel>(
                mContext,
                mContext.Licenses,
                LicenseEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the licenses from the database
        /// </summary>
        /// Get home/licenses
        [HttpGet]
        [Route(Routes.LicensesRoute)]
        public Task<ActionResult<IEnumerable<LicenseResponseModel>>> GetLicensesAsync([FromQuery] LicenseArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<LicenseEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.LicenseKey.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the After Activation Date is not null...
            if (args.AfterActivationDate is not null)
                // Add to filters
                filters.Add(x => x.ActivationDate >= args.AfterActivationDate);

            // If the Before Activation Created is not null...
            if (args.BeforeActivationDate is not null)
                // Add to filters
                filters.Add(x => x.ActivationDate <= args.BeforeActivationDate);

            // If the After Expiration Date is not null...
            if (args.AfterExpirationDate is not null)
                // Add to filters
                filters.Add(x => x.ExpirationDate >= args.AfterExpirationDate);

            // If the Before Expiration Created is not null...
            if (args.BeforeExpirationDate is not null)
                // Add to filters
                filters.Add(x => x.ExpirationDate <= args.BeforeExpirationDate);

            // If the included Licenses is not null...
            if (args.IncludeCompanies is not null)
                // Add to filters
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            // If the excluded Licenses is not null...
            if (args.ExcludeCompanies is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            // Gets the response models for each user entity
            return ControllerHelpers.GetAllAsync<LicenseEntity, LicenseResponseModel>(
                LicensesQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the license with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="licenseId">The license's id</param>
        /// Get home/licenses/{licenseId} == home/license/2
        [HttpGet]
        [Route(Routes.LicenseRoute)]
        public Task<ActionResult<LicenseResponseModel>> GetLicenseAsync([FromRoute] int licenseId)
        {
            // The needed expression for the filter
            Expression<Func<LicenseEntity, bool>> filter = x => x.Id == licenseId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<LicenseEntity, LicenseResponseModel>(
                LicensesQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the license with the specified id
        /// </summary>
        /// <param name="licenseId">The license's id</param>
        /// <param name="model">The license request model</param>
        /// Put /home/licenses/{licenseId}
        [HttpPut]
        [Route(Routes.LicenseRoute)]
        public Task<ActionResult<LicenseResponseModel>> UpdateLicenseAsync([FromRoute] int licenseId, [FromBody] LicenseRequestModel model)
        {
            return ControllerHelpers.PutAsync<LicenseRequestModel, LicenseEntity, LicenseResponseModel>(
                mContext,
                LicensesQuery,
                model,
                x => x.Id == licenseId);
        }

        /// <summary>
        /// Deletes the license with the specified id if exists from the database
        /// </summary>
        /// <param name="licenseId">The license's id</param>
        /// Delete /home/licenses/{licenseId}
        [HttpDelete]
        [Route(Routes.LicenseRoute)]
        public Task<ActionResult<LicenseResponseModel>> DeleteUserAsync([FromRoute] int licenseId)
        {
            return ControllerHelpers.DeleteAsync<LicenseEntity, LicenseResponseModel>(
                mContext,
                LicensesQuery,
                DI.GetMapper,
                x => x.Id == licenseId);
        }

        #endregion
    }
}
