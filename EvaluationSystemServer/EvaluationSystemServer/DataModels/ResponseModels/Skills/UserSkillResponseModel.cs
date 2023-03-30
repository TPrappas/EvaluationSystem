namespace EvaluationSystemServer
{
    public class UserSkillResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="UserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel? User { get; set; }

        /// <summary>
        /// The related <see cref="SkillResponseModel"/>
        /// </summary>
        public SkillResponseModel? Skill { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserSkillResponseModel() : base()
        {

        }

        #endregion

    }

    public class EmbeddedUserSkillResponseModel : UserSkillResponseModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedUserSkillResponseModel() : base()
        {

        }

        #endregion
    }
}
