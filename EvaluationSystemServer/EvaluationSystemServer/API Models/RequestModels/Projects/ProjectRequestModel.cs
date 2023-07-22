namespace EvaluationSystemServer
{ 
    public class ProjectRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The user's id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// The project is Submitted
        /// </summary>
        public bool isSubmitted { get; set; }

        /// <summary>
        /// The starting date
        /// </summary>
        public DateTimeOffset? StartingDate { get; set; }

        /// <summary>
        /// The ending date
        /// </summary>
        public DateTimeOffset? EndingDate { get; set; }

        /// <summary>
        /// The category's id
        /// </summary>
        public IEnumerable<int>? Categories { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectRequestModel() : base()
        {

        }

        #endregion
    }

    public class CreateProjectRequestModel : ProjectRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateProjectRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateProjectRequestModel : ProjectRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateProjectRequestModel() : base()
        {

        }

        #endregion
    }
}
