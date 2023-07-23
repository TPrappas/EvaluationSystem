namespace EvaluationSystemServer
{ 
    public class LicenseRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The license key
        /// </summary>
        public string? LicenseKey { get; set; }

        /// <summary>
        /// The activation Date
        /// </summary>
        public DateTimeOffset? ActivationDate { get; set; }

        /// <summary>
        /// The expiration date
        /// </summary>
        public DateTimeOffset? ExpirationDate { get; set; }

        /// <summary>
        /// Is the license active
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// The company's id
        /// </summary>
        public int? CompanyId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LicenseRequestModel() : base()
        {

        }

        #endregion
    }
}
