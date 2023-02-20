namespace EvaluationSystemServer
{
    public class SkillResponseModel : BaseResponseModel
    {
        #region Public Properties

        public string Name { get; set; }

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
