namespace EvaluationSystemServer
{
    public class LicenseResponseModel : DateResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="LicenseKey"/> property
        /// </summary>
        private string? mLicenseKey;

        #endregion

        #region Public Properties

        /// <summary>
        /// The license key
        /// </summary>
        public string LicenseKey
        {
            get => mLicenseKey ?? string.Empty;

            set => mLicenseKey = value;
        }

        /// <summary>
        /// The activation Date
        /// </summary>
        public DateTimeOffset ActivationDate { get; set; }

        /// <summary>
        /// The expiration date
        /// </summary>
        public DateTimeOffset ExpirationDate { get; set; }

        /// <summary>
        /// Is the license active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        public EmbeddedCompanyResponseModel? Company { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LicenseResponseModel() : base()
        {

        }

        #endregion

    }
}
