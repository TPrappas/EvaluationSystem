namespace EvaluationSystemServer
{
    public class ProjectCategoryResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="ProjectResponseModel"/>
        /// </summary>
        public ProjectResponseModel Project { get; set; }


        /// <summary>
        /// The related <see cref="CategoryResponseModel"/>
        /// </summary>
        public CategoryResponseModel Category { get; set; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCategoryResponseModel() 
        { 
        
        }
        
        #endregion
    }
}
