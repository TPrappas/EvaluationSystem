namespace EvaluationSystemServer
{
    public class AdminArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminArgs() : base()
        {

        }

        #endregion
    }
}
