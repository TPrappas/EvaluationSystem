using Microsoft.AspNetCore.Mvc;
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
        public Task<ActionResult<CompanyResponseModel>> CreateCompanyAsync([FromBody] CompanyRequestModel model)
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
        public Task<ActionResult<IEnumerable<CompanyResponseModel>>> GetCompaniesAsync() =>
            // Gets the response models for each companies entity
            ControllerHelpers.GetAllAsync<CompanyEntity, CompanyResponseModel>(
                mContext.Companies,
                x => true);

        /// <summary>
        /// Gets the company with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// Get api/companies/{companyId} == api/companies/1
        [HttpGet]
        [Route(Routes.CompanyRoute)]
        public Task<ActionResult<CompanyResponseModel>> GetCompanyAsync([FromRoute] int companyId)
        {
            // The needed expression for the filter
            Expression<Func<CompanyEntity, bool>> filter = x => x.Id == companyId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<CompanyEntity, CompanyResponseModel>(
                mContext.Companies,
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
        public Task<ActionResult<CompanyResponseModel>> UpdateCompanyAsync([FromRoute] int companyId, [FromBody] CompanyRequestModel model)
        {
            return ControllerHelpers.PutAsync<CompanyRequestModel, CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
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
        public Task<ActionResult<CompanyResponseModel>> DeleteCompanyAsync(int companyId)
        {
            return ControllerHelpers.DeleteAsync<CompanyEntity, CompanyResponseModel>(
                mContext,
                mContext.Companies,
                DI.GetMapper,
                x => x.Id == companyId);
        }

        #endregion
    }
}
