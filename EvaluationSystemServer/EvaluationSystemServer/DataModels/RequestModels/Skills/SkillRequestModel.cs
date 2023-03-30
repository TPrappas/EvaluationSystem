namespace EvaluationSystemServer
{
    public class SkillRequestModel : BaseRequestModel
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
