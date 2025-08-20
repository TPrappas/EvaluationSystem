namespace EvaluationSystemServer
{
    public class CategoryArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search { get; set; }

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
