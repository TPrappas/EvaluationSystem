﻿namespace EvaluationSystemServer
{
    public abstract class DateResponseModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The date created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date updated
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DateResponseModel() 
        { 
        
        }

        #endregion
    }
}
