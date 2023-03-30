namespace EvaluationSystemServer
{
    public class CategoryEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The category's projects
        /// </summary>
        public IEnumerable<ProjectCategoryEntity>? ProjectsCategory { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CategoryEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CategoryEntity FromRequestModel(CreateCategoryRequestModel model)
            => ControllerHelpers.FromRequestModel<CategoryEntity, CreateCategoryRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CategoryResponseModel"/> from the current <see cref="CategoryEntity"/>
        /// </summary>
        /// <returns></returns>
        public CategoryResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CategoryEntity, CategoryResponseModel>(this);

        #endregion

    }
}
