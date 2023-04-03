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

        /// <summary>
        /// The member of the <see cref="IncludeCompanies"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeCompanies;

        /// <summary>
        /// The member of the <see cref="ExcludeCompanies"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeCompanies;

        /// <summary>
        /// The member of the <see cref="IncludeJobPositions"/> property
        /// </summary>
        private IEnumerable<int>? mIncludedJobPositions;

        /// <summary>
        /// The member of the <see cref="ExcludeJobPositions"/> property
        /// </summary>
        private IEnumerable<int>? mExcludedJobPositions;

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
        public IEnumerable<int> IncludeCompanies
        {
            get => mIncludeCompanies ?? Enumerable.Empty<int>();

            set => mIncludeCompanies = value;
        }

        /// <summary>
        /// Company excluded
        /// </summary>
        public IEnumerable<int> ExcludeCompanies
        {
            get => mExcludeCompanies ?? Enumerable.Empty<int>();

            set => mExcludeCompanies = value;
        }

        /// <summary>
        /// Job position included
        /// </summary>
        public IEnumerable<int> IncludeJobPositions
        { 
            get => mIncludedJobPositions ?? Enumerable.Empty<int>();

            set => mIncludedJobPositions = value;
        }

        /// <summary>
        /// Job position excluded
        /// </summary>
        public IEnumerable<int> ExcludeJobPositions
        {
            get => mExcludedJobPositions ?? Enumerable.Empty<int>();

            set => mExcludedJobPositions = value;
        }

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
