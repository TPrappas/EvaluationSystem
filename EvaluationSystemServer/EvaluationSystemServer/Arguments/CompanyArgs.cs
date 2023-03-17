namespace EvaluationSystemServer
{
    public class CompanyArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By Name
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// By DOY
        /// </summary>
        public string DOY { get; set; }

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
