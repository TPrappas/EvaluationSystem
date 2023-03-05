namespace EvaluationSystemServer
{
    public class UserSkillResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity User { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="SkillEntity"/>
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// The related <see cref="SkillEntity"/>
        /// </summary>
        public SkillEntity Skill { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserSkillResponseModel()
        {

        }

        #endregion

    }
}
