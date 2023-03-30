namespace EvaluationSystemServer
{
    public class CertificateRequestModel : BaseRequestModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Department"/> property
        /// </summary>
        private string? mDepartment;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;

            set => mName = value;
        }

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
        public double GradutationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

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
