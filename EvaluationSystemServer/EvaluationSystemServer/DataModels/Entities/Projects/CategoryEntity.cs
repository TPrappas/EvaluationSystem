namespace EvaluationSystemServer
{
    public class CategoryEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The category's projects
        /// </summary>
        public IEnumerable<ProjectCategoryEntity> ProjectsCategory { get; set; }

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
        public static CategoryEntity FromRequestModel(CategoryRequestModel model)
            => ControllerHelpers.FromRequestModel<CategoryEntity, CategoryRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CategoryResponseModel"/> from the current <see cref="CategoryEntity"/>
        /// </summary>
        /// <returns></returns>
        public CategoryResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CategoryEntity, CategoryResponseModel>(this);

        #endregion

    }
}
