namespace EvaluationSystemServer
{
    public class JobResponseModel : NormalizedResponseModel
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

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobResponseModel() : base()
        {

        }

        #endregion
    }

    public class EmbeddedJobResponseModel : NormalizedResponseModel
    { 
        #region Public Properties

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedJobResponseModel() : base()
        {

        }

        #endregion
    }
}
