namespace EvaluationSystemServer
{
    public class SkillResponseModel : BaseResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Experience"/> property
        /// </summary>
        private string? mExperience;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;

            set => mName = value;
        }

        /// <summary>
        /// The experience
        /// </summary>
        public string Experience
        {
            get => mExperience ?? string.Empty;

            set => mExperience = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SkillResponseModel() : base()
        {

        }

        #endregion
    }

    public class EmbeddedSkillResponseModel : SkillResponseModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedSkillResponseModel() : base()
        {

        }

        #endregion
    }
}
