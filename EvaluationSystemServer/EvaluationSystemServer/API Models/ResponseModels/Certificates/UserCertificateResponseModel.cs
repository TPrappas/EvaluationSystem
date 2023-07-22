namespace EvaluationSystemServer
{
    public class UserCertificateResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="UserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel? User { get; set; }

        /// <summary>
        /// The related <see cref="CertificateResponseModel"/>
        /// </summary>
        public CertificateResponseModel? Certificate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserCertificateResponseModel() : base()
        {

        }

        #endregion
    }

    public class EmbeddedUserCertificateResponseModel : UserCertificateResponseModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedUserCertificateResponseModel() : base()
        {

        }

        #endregion
    }
}
