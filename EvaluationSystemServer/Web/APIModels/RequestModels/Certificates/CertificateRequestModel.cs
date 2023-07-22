namespace EvaluationSystemServer
{
    public class CertificateRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The department
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// The graduation year
        /// </summary>
        public int? GradutationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double? Grade { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        public CertificateRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateCertificateRequestModel : CertificateRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateCertificateRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateCertificateRequestModel : CertificateRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateCertificateRequestModel() : base()
        {

        }

        #endregion
    }
}
