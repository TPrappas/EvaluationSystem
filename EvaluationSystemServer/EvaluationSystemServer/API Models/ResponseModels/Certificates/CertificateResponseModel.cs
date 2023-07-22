namespace EvaluationSystemServer
{
    public class CertificateResponseModel : NormalizedResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Department"/> property
        /// </summary>
        private string? mDepartment;

        #endregion

        #region Public Properties

        /// <summary>
        /// The department
        /// </summary>
        public string Department
        {
            get => mDepartment ?? string.Empty;

            set => mDepartment = value;
        }

        /// <summary>
        /// The graduation year
        /// </summary>
        public int GradutationYear { get; set; }

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

    public class EmbeddedCertificateResponseModel : NormalizedResponseModel
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
