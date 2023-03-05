namespace EvaluationSystemServer
{
    public class CategoryRequestModel : BaseRequestModel
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
        public CategoryRequestModel()
        { 
        
        }

        #endregion
    }
}
