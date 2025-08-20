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
        /// The normalized <see cref="Name"/>
        /// </summary>
        //public string NormalizedName
        //{
        //    get => ControllerHelpers.NormalizeString(LicenseKey);

        //    set { }
        //}

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

        /// <summary>
        /// Creates and returns a <see cref="LicenseEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static LicenseEntity FromRequestModel(LicenseRequestModel model)
            => ControllerHelpers.FromRequestModel<LicenseEntity, LicenseRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="LicenseResponseModel"/> from the current <see cref="LicenseEntity"/>
        /// </summary>
        /// <returns></returns>
        public LicenseResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<LicenseEntity, LicenseResponseModel>(this);

        #endregion
    }
}
