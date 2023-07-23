using System.Collections.ObjectModel;

namespace EvaluationSystemServer
{
    public class LicenseEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CompanyEntity"/>
        /// </summary>
        /// The id of the related company
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyEntity"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public CompanyEntity? Company { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LicenseEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        #endregion
    }
}
