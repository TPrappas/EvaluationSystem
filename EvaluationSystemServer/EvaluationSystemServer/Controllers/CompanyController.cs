using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class CompanyController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Companies
        /// </summary>
        protected IQueryable<CompanyEntity> CompaniesQuery => mContext.Companies.Include(x => x.Users).Include(x => x.JobPositions);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public CompanyController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new company
        /// </summary>
        /// Post api/companies
        [HttpPost]
        [Route(Routes.CompaniesRoute)]
        public Task<ActionResult<CompanyResponseModel>> CreateCompanyAsync([FromBody] CreateCompanyRequestModel model)
            => ControllerHelpers.PostAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
                CompanyEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the companies from the database
        /// </summary>
        /// Get api/companies
        [HttpGet]
        [Route(Routes.CompaniesRoute)]
        public Task<ActionResult<IEnumerable<EmbeddedCompanyResponseModel>>> GetCompaniesAsync([FromQuery] CompanyArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<CompanyEntity, bool>>>();

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

            // If Country is not null...
            if (!string.IsNullOrEmpty(args.Country))
                // Add to filters
                filters.Add(x => x.Country.Contains(args.Country));

            // If DOY is not null...
            if (!string.IsNullOrEmpty(args.DOY))
                // Add to filters
                filters.Add(x => x.DOY.Contains(args.DOY));

            // Gets the response models for each companies entity
            return ControllerHelpers.GetAllAsync<CompanyEntity, EmbeddedCompanyResponseModel>(
                CompaniesQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the company with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get api/companies/{companyId} == api/companies/1
        [HttpGet]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<EmbeddedCompanyResponseModel>> GetCompanyAsync([FromRoute] int companyId)
        {
            // The needed expression for the filter
            Expression<Func<CompanyEntity, bool>> filter = x => x.Id == companyId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<CompanyEntity, EmbeddedCompanyResponseModel>(
                CompaniesQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the company with the specified id
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="model">The company request model</param>
        /// Put /api/companies/{companyId}
        [HttpPut]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> UpdateCompanyAsync([FromRoute] int companyId, [FromBody] UpdateCompanyRequestModel model)
        {
            return ControllerHelpers.PutAsync<UpdateCompanyRequestModel, CompanyEntity, CompanyResponseModel>(
                mContext,
                CompaniesQuery,
                model,
                x => x.Id == companyId);
        }

        /// <summary>
        /// Deletes the company with the specified id if exists from the database
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Delete /api/companies/{companyId}
        [HttpDelete]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> DeleteCompanyAsync([FromRoute] int companyId)
        {
            return ControllerHelpers.DeleteAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                CompaniesQuery,
                DI.GetMapper,
                x => x.Id == companyId);
        }

        #endregion
    }
}
