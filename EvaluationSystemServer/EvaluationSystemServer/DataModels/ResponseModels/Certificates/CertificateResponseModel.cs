namespace EvaluationSystemServer
{
    public class CertificateResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// The graduation year
        /// </summary>
        public double GradutationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CertificateResponseModel() : base()
        {

        }

        #endregion
    }

    public class EmbeddedCertificateResponseModel : CertificateResponseModel
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EmbeddedCertificateResponseModel() : base() 
        { 
        
        }

        #endregion
    }
}
