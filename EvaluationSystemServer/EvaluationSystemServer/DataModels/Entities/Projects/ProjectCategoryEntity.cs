namespace EvaluationSystemServer
{
    public class ProjectCategoryEntity : BaseEntity
    {
        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The related <see cref="ProjectEntity"/>
        /// </summary>
        public ProjectEntity Project { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CategoryEntity"/>
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The related <see cref="CategoryEntity"/>
        /// </summary>
        public CategoryEntity Category { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCategoryEntity()
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ProjectCategoryResponseModel"/> from the current <see cref="ProjectCategoryEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProjectCategoryResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<ProjectCategoryEntity, ProjectCategoryResponseModel>(this);
                
        #endregion
    }
}
