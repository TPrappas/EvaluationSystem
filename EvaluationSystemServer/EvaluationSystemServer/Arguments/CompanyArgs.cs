namespace EvaluationSystemServer
{
    public class CompanyArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="Country"/> property
        /// </summary>
        private string? mCountry;

        /// <summary>
        /// The member of the <see cref="DOY"/> property
        /// </summary>
        private string? mDOY;

        #endregion

        #region Public Properties

        /// <summary>
        /// By Name
        /// </summary>
        public string Search 
        {
            get => mSearch ?? string.Empty;

            set => mSearch = value;
        }

        /// <summary>
        /// By country
        /// </summary>
        public string Country
        { 
            get => mCountry ?? string.Empty;
            
            set => mCountry = value; 
        }

        /// <summary>
        /// By DOY
        /// </summary>
        public string DOY
        { 
            get => mDOY ?? string.Empty; 
            
            set => mDOY = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyArgs()
        {

        }

        #endregion

    }
}
