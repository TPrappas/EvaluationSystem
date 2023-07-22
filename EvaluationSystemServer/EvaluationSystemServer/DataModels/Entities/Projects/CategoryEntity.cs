using System.Collections.ObjectModel;

namespace EvaluationSystemServer
{
    public class CategoryEntity : NormalizedEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="ProjectsCategory"/> property
        /// </summary>
        private ICollection<ProjectCategoryEntity>? mProjectsCategory;

        #endregion

        #region Public Properties

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
        public ICollection<ProjectCategoryEntity> ProjectsCategory 
        { 
            get => mProjectsCategory ??= new Collection<ProjectCategoryEntity>();
            
            set => mProjectsCategory = value;
        }

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
