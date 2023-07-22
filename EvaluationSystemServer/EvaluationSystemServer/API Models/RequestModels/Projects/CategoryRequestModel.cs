namespace EvaluationSystemServer
{
    public class CategoryRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string? Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryRequestModel() : base()
        { 
        
        }

        #endregion
    }

    public class CreateCategoryRequestModel : CategoryRequestModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateCategoryRequestModel() : base()
        {

        }

        #endregion
    }

    public class UpdateCategoryRequestModel : CategoryRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateCategoryRequestModel() : base()
        {

        }

        #endregion
    }
}
