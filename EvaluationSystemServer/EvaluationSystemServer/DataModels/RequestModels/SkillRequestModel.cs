namespace EvaluationSystemServer.DataModels.RequestModels
{
    public class SkillRequestModel : BaseRequestModel
    {
        #region Public Properties

        public string Name { get; set; }

        public string Experience { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SkillRequestModel() 
        { 
        
        }

        #endregion

    }
}
