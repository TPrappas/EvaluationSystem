namespace EvaluationSystemServer
{
    public class CategoryArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        #endregion

        #region Public Properties

        /// <summary>
        /// By name
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
        public CategoryArgs() : base()
        {

        }

        #endregion

    }
}
