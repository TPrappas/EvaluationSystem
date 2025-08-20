namespace EvaluationSystemServer
{
    public class JobArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By min salary
        /// </summary>
        public decimal? MinSalary { get; set; }

        /// <summary>
        /// By max salary
        /// </summary>
        public decimal? MaxSalary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobArgs() : base()
        {

        }

        #endregion
    }
}
