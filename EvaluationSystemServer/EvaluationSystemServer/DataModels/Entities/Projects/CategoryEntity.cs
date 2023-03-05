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
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The related <see cref="ProjectEntity"/>
        /// </summary>
        public ProjectEntity Project { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CategoryEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="projectId">The project's id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CategoryEntity FromRequestModel(int projectId, CategoryRequestModel model)
            => ControllerHelpers.FromRequestModel(model, (CategoryEntity entity) => { entity.ProjectId = projectId; });

        /// <summary>
        /// Creates and returns a <see cref="CategoryResponseModel"/> from the current <see cref="CategoryEntity"/>
        /// </summary>
        /// <returns></returns>
        public CategoryResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CategoryEntity, CategoryResponseModel>(this);

        #endregion

    }
}
