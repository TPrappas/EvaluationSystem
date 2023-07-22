namespace EvaluationSystemServer
{
    public class SkillRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The experience
        /// </summary>
        public string? Experience { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SkillRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateSkillRequestModel : SkillRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateSkillRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateSkillRequestModel : SkillRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateSkillRequestModel() : base()
        {

        }

        #endregion
    }
}
