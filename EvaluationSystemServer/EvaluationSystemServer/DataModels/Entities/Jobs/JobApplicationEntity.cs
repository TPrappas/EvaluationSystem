﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class JobApplicationEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }


        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        /// The employee
        public UserEntity User { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobPositionEntity"/>
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="OpenJobPositionEntity"/>
        /// </summary>
        public JobPositionEntity JobPosition { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobApplicationEntity() 
        { 
        
        }

        #endregion

    }
}
