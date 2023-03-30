namespace EvaluationSystemServer
{
    public class CategoryRequestModel : BaseRequestModel
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
