using EvaluationSystemServer.DataModels.RequestModels.Certificates;
using EvaluationSystemServer.DataModels.ResponseModels.Certificates;
using Microsoft.AspNetCore.Mvc;
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
            => ControllerHelpers.PostAsync<CertificateEntity, CertificateResponseModel>(
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
        public Task<ActionResult<IEnumerable<CertificateResponseModel>>> GetCertificatesAsync() =>
            // Gets the response models for each certificate entity
            ControllerHelpers.GetAllAsync<CertificateEntity, CertificateResponseModel>(
                mContext.Certificates,
                x => true);

        /// <summary>
        /// Gets the certificate with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="certificateId">The certificate's id</param>
        /// Get api/certificates/{certificateId} == api/certificates/1
        [HttpGet]
        [Route(Routes.AdminRoute)]
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
