namespace EvaluationSystemServer
{
    public class UserArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="FirstName"/> property
        /// </summary>
        private string? mFirstName;

        /// <summary>
        /// The member of the <see cref="LastName"/> property
        /// </summary>
        private string? mLastName;

        #endregion

        #region Public Properties 

        /// <summary>
        /// By username
        /// </summary>
        public string Search
        { 
            get => mSearch ?? string.Empty; 
            
            set => mSearch = value;
        }

        /// <summary>
        /// By firstname
        /// </summary>
        public string FirstName
        { 
            get => mFirstName ?? string.Empty; 
            
            set => mFirstName = value;
        }

        /// <summary>
        /// By lastname
        /// </summary>
        public string LastName
        {
            get => mLastName ?? string.Empty;

            set => mLastName = value;
        }

        /// <summary>
        /// By minRating
        /// </summary>
        public double? MinRating { get; set; }

        /// <summary>
        /// By maxRating
        /// </summary>
        public double? MaxRating { get; set; }

        /// <summary>
        /// By staff type
        /// </summary>
        public StaffType? UserType { get; set; }

        /// <summary>
        /// Company included
        /// </summary>
        public IEnumerable<int>? IncludeCompanies { get; set; }

        /// <summary>
        /// Company excluded
        /// </summary>
        public IEnumerable<int>? ExcludeCompanies { get; set; }

        /// <summary>
        /// Job position included
        /// </summary>
        public IEnumerable<int>? IncludeJobPositions { get; set; }

        /// <summary>
        /// Job position excluded
        /// </summary>
        public IEnumerable<int>? ExcludeJobPositions { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserArgs()
        {

        }

        #endregion
    }
}
