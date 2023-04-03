using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class SkillEntity : BaseEntity
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

        /// <summary>
        /// The member of the <see cref="UserSkills"/> property
        /// </summary>
        private ICollection<UserSkillEntity>? mUserSkills;

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

        #region Relationships

        /// <summary>
        /// The related <see cref="SkillEntity"/>
        /// </summary>
        public ICollection<UserSkillEntity> UserSkills 
        { 
            get => mUserSkills ??= new Collection<UserSkillEntity>();
            
            set => mUserSkills = value;
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SkillEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="SkillEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SkillEntity FromRequestModel(SkillRequestModel model)
            => ControllerHelpers.FromRequestModel<SkillEntity, SkillRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="SkillResponseModel"/> from the current <see cref="SkillEntity"/>
        /// </summary>
        /// <returns></returns>
        public SkillResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<SkillEntity, SkillResponseModel>(this);


        #endregion
    }
}
