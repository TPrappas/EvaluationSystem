namespace EvaluationSystemServer
{
    public class CompanyRequestModel
    {
        #region Private Properties

        /// <summary>
        /// The member of the <see cref="DOY"/> property
        /// </summary>
        private string? mDOY;

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Phone"/> property
        /// </summary>
        private string? mPhone;

        /// <summary>
        /// The member of the <see cref="Address"/> property
        /// </summary>
        private string? mAddress;

        /// <summary>
        /// The member of the <see cref="City"/> property
        /// </summary>
        private string? mCity;

        /// <summary>
        /// The member of the <see cref="Country"/> property
        /// </summary>
        private string? mCountry;

        #endregion

        #region Public Properties

        /// <summary>
        /// The AFM
        /// </summary>
        public int AFM { get; set; }

        /// <summary>
        /// The DOY
        /// </summary>
        public string DOY
        {
            get => mDOY ?? string.Empty;

            set => mDOY = value;
        }

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;

            set => mName = value;
        }

        /// <summary>
        /// The phone
        /// </summary>
        public string Phone
        {
            get => mPhone ?? string.Empty;

            set => mPhone = value;
        }

        /// <summary>
        /// The website
        /// </summary>
        public Uri? Website { get; set; }

        /// <summary>
        /// The Address
        /// </summary>
        public string Address
        {
            get => mAddress ?? string.Empty;

            set => mAddress = value;
        }

        /// <summary>
        /// The city
        /// </summary>
        public string City
        {
            get => mCity ?? string.Empty;

            set => mCity = value;
        }

        /// <summary>
        /// The country
        /// </summary>
        public string Country
        {
            get => mCountry ?? string.Empty;

            set => mCountry = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateCompanyRequestModel : CompanyRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateCompanyRequestModel() : base()
        {

        }

        #endregion

    }

    public class UpdateCompanyRequestModel : CompanyRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateCompanyRequestModel() : base()
        {

        }

        #endregion
    }
}

