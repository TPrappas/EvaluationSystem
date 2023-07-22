namespace EvaluationSystemServer
{
    public class CategoryResponseModel : NormalizedResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

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
