namespace EvaluationSystemServer
{
    public class AdminArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By username
        /// </summary>
        public string Search { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminArgs()
        {

        }

        #endregion
    }
}
