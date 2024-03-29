﻿namespace EvaluationSystemServer
{
    public class JobApplicationResponseModel : DateResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// The submission start
        /// </summary>
        public DateTimeOffset SubmissionStart { get; set; }

        /// <summary>
        /// The submission end
        /// </summary>
        public DateTimeOffset SubmissionEnd { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The manager
        public EmbeddedUserResponseModel? Manager { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The evaluator
        public EmbeddedUserResponseModel? Evaluator { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The employee
        public EmbeddedUserResponseModel? Employee { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionResponseModel"/>
        /// </summary>
        public JobPositionResponseModel? JobPosition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationResponseModel() : base()
        {

        }

        #endregion

    }

    public class EmbeddedJobApplicationResponseModel : DateResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The manager
        public EmbeddedUserResponseModel? Manager { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The evaluator
        public EmbeddedUserResponseModel? Evaluator { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        /// The employee
        public EmbeddedUserResponseModel? Employee { get; set; }

        /// <summary>
        /// The related <see cref="EmbeddedJobPositionResponseModel"/>
        /// </summary>
        public EmbeddedJobPositionResponseModel? JobPosition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedJobApplicationResponseModel() : base()
        {

        }

        #endregion
    }
}
