namespace EvaluationSystemServer
{ 
    public class ProjectRequestModel : BaseRequestModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="ProjectCategories"/> property
        /// </summary>
        private IEnumerable<int>? mCategories;

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
        /// The description
        /// </summary>
        public string Description
        {
            get => mDescription ?? string.Empty;

            set => mDescription = value;
        }

        /// <summary>
        /// The user's id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The project is Submitted
        /// </summary>
        public bool isSubmitted { get; set; }

        /// <summary>
        /// The starting date
        /// </summary>
        public DateTimeOffset StartingDate { get; set; }

        /// <summary>
        /// The ending date
        /// </summary>
        public DateTimeOffset EndingDate { get; set; }

        /// <summary>
        /// The category's id
        /// </summary>
        public IEnumerable<int> Categories
        {
            get => mCategories ?? Enumerable.Empty<int>();

            set => mCategories = value;
        }

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
