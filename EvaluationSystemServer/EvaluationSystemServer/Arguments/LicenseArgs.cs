namespace EvaluationSystemServer
{
    public class LicenseArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By LicenseKey
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// By after activation date
        /// </summary>
        public DateTimeOffset? AfterActivationDate { get; set; }

        /// <summary>
        /// By before activation date
        /// </summary>
        public DateTimeOffset? BeforeActivationDate { get; set; }

        /// <summary>
        /// By after expiration date
        /// </summary>
        public DateTimeOffset? AfterExpirationDate { get; set; }

        /// <summary>
        /// By before expiration date
        /// </summary>
        public DateTimeOffset? BeforeExpirationDate { get; set; }

        /// <summary>
        /// By id expired
        /// </summary>
        public bool? IsExpired { get; set; }

        /// <summary>
        /// Companies included
        /// </summary>
        public IEnumerable<int>? IncludeCompanies { get; set; }

        /// <summary>
        /// Companies excluded
        /// </summary>
        public IEnumerable<int>? ExcludeCompanies { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LicenseArgs() : base()
        {

        }

        #endregion
    }
}
