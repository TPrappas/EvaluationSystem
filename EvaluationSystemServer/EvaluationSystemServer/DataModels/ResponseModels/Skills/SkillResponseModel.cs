namespace EvaluationSystemServer
{
    public class SkillResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The experience
        /// </summary>
        public string Experience { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SkillResponseModel()
        {

        }

        #endregion
    }
}
