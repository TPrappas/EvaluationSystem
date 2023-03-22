using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class CertificateController : Controller
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
        public CertificateController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new certificates
        /// </summary>
        /// Post api/certificates
        [HttpPost]
        [Route(Routes.CertificatesRoute)]
        public Task<ActionResult<CertificateResponseModel>> CreateCertificateAsync([FromBody] CertificateRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Certificates,
                CertificateEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the certificates from the database
        /// </summary>
        /// Get api/certificates
        [HttpGet]
        [Route(Routes.CertificatesRoute)]
        public Task<ActionResult<IEnumerable<CertificateResponseModel>>> GetCertificatesAsync([FromQuery] CertificateArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<CertificateEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Name.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the After Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If Department is not null...
            if (!string.IsNullOrEmpty(args.Department))
                // Add to filters
                filters.Add(x => x.Department.Contains(args.Department));

            // If the Min Grade is not null...
            if (args.MinGrade is not null)
                // Add to filters
                filters.Add(x => args.MinGrade >= x.Grade);

            // If the Min Grade is not null...
            if (args.MaxGrade is not null)
                // Add to filters
                filters.Add(x => args.MaxGrade <= x.Grade);

            // Gets the response models for each certificate entity
            return ControllerHelpers.GetAllAsync<CertificateEntity, CertificateResponseModel>(
                mContext.Certificates,
                args,
                filters);
        }

        /// <summary>
        /// Gets the certificate with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="certificateId">The certificate's id</param>
        /// Get api/certificates/{certificateId} == api/certificates/1
        [HttpGet]
        [Route(Routes.CertificateRoute)]
        public Task<ActionResult<CertificateResponseModel>> GetCertificateAsync([FromRoute] int certificateId)
        {
            // The needed expression for the filter
            Expression<Func<CertificateEntity, bool>> filter = x => x.Id == certificateId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<CertificateEntity, CertificateResponseModel>(
                mContext.Certificates,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the certificate with the specified id
        /// </summary>
        /// <param name="certificateId">The certificate's id</param>
        /// <param name="model">The certificate request model</param>
        /// Put /api/certificates/{certificatesId}
        [HttpPut]
        [Route(Routes.CertificateRoute)]
        public Task<ActionResult<CertificateResponseModel>> UpdateCertificateAsync([FromRoute] int certificateId, [FromBody] CertificateRequestModel model)
        {
            return ControllerHelpers.PutAsync<CertificateRequestModel, CertificateEntity, CertificateResponseModel>(
                mContext,
                mContext.Certificates,
                model,
                x => x.Id == certificateId);
        }

        /// <summary>
        /// Deletes the certificate with the specified id if exists from the database
        /// </summary>
        /// <param name="certificateId">The certificate's id</param>
        /// Delete /api/certificates/{certificateId}
        [HttpDelete]
        [Route(Routes.CertificateRoute)]
        public Task<ActionResult<CertificateResponseModel>> DeleteCertificateAsync(int certificateId)
        {
            return ControllerHelpers.DeleteAsync<CertificateEntity, CertificateResponseModel>(
                mContext,
                mContext.Certificates,
                DI.GetMapper,
                x => x.Id == certificateId);
        }

        #endregion
    }
}
