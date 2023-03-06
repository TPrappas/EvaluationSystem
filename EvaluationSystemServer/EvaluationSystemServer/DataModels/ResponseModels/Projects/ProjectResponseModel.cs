namespace EvaluationSystemServer
{
    public class ProjectResponseModel : BaseResponseModel
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

        /// <summary>
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel User { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectResponseModel()
        {

        }

        #endregion

    }
}
