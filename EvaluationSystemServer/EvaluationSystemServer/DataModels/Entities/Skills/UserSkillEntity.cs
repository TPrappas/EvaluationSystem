using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class UserSkillEntity : BaseEntity
    {
        #region Public Properties

        #region Relationships

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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserSkillEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="UserSkillResponseModel"/> from the current <see cref="UserSkillEntity"/>
        /// </summary>
        /// <returns></returns>
        public UserSkillResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<UserSkillEntity, UserSkillResponseModel>(this);

        #endregion
    }
}
