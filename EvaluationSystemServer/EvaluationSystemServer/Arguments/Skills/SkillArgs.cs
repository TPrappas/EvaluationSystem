namespace EvaluationSystemServer
{
    public class SkillArgs : BaseArgs
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
        public SkillArgs() : base()
        {

        }

        #endregion
    }
}
