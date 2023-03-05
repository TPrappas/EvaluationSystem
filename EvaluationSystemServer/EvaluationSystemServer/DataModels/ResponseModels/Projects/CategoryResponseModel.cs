namespace EvaluationSystemServer
{
    public class CategoryResponseModel : BaseResponseModel
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
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The related <see cref="ProjectEntity"/>
        /// </summary>
        public ProjectEntity Project { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryResponseModel() 
        { 
        
        }

        #endregion
    }
}
