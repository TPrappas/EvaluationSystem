
namespace EvaluationSystemServer
{
    public class UserCertificateResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity User { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CertificateEntity"/>
        /// </summary>
        public int CertificateId { get; set; }

        /// <summary>
        /// The related <see cref="CertificateEntity"/>
        /// </summary>
        public CertificateEntity Certificate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserCertificateResponseModel() 
        {
        
        }

        #endregion
    }
}
