﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class SkillEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The related <see cref="SkillEntity"/>
        /// </summary>
        public IEnumerable<UserSkillEntity> UserSkills { get; set; }

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
