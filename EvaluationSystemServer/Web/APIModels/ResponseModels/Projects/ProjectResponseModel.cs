namespace EvaluationSystemServer
{
    public class ProjectResponseModel : BaseResponseModel
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
        /// The project is submitted
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
        /// The related <see cref="EmbeddedUserResponseModel"/>
        /// </summary>
        public EmbeddedUserResponseModel? User { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectResponseModel() : base()
        {

        }

        #endregion

    }

    public class EmbeddedProjectResponseModel : ProjectResponseModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedProjectResponseModel() : base()
        {

        }

        #endregion
    }
}
