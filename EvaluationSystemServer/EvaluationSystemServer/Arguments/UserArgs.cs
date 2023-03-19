namespace EvaluationSystemServer
{
    public class UserArgs : BaseArgs
    {
        #region Public Properties 

        /// <summary>
        /// By username
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// By lastname
        /// </summary>
        public string LastName { get; set; }

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
        public IEnumerable<int> IncludeCompanies { get; set; }

        /// <summary>
        /// Company excluded
        /// </summary>
        public IEnumerable<int> ExcludeCompanies { get; set; }

        /// <summary>
        /// Job position included
        /// </summary>
        public IEnumerable<int> IncludeJobPositions { get; set; }

        /// <summary>
        /// Job position excluded
        /// </summary>
        public IEnumerable<int> ExcludeJobPositions { get; set; }

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
