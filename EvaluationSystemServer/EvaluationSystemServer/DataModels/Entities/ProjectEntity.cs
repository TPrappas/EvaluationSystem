﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class ProjectEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The starting date
        /// </summary>
        public DateTimeOffset StartingDate { get; set; }

        /// <summary>
        /// The ending date
        /// </summary>
        public DateTimeOffset EndingDate { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity Employee { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectEntity() 
        { 
        
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ProjectEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static ProjectEntity FromRequestModel(ProjectRequestModel model)
            => ControllerHelpers.FromRequestModel<ProjectEntity, ProjectRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="ProjectResponseModel"/> from the current <see cref="ProjectEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProjectResponseModel ToResponseModel() => ControllerHelpers.ToResponseModel<ProjectEntity, ProjectResponseModel>(this);

        #endregion

    }
}
