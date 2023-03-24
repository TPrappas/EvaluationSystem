namespace EvaluationSystemServer
{
    public class CompanyRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The AFM
        /// </summary>
        public int AFM { get; set; }

        /// <summary>
        /// The DOY
        /// </summary>
        public string DOY { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// The Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; set; }


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
}

