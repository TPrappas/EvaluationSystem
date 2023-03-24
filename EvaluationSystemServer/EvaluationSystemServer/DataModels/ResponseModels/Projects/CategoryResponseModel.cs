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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryResponseModel() : base()
        { 
        
        }

        #endregion
    }

    public class EmbeddedCategoryResponseModel : CategoryResponseModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedCategoryResponseModel() : base()
        {

        }

        #endregion
    }
}
