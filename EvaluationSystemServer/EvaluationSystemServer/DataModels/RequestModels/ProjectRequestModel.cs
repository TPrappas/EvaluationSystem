namespace EvaluationSystemServer
{
    public class ProjectRequestModel : BaseRequestModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectRequestModel() 
        { 
        
        }

        #endregion
    }
}
