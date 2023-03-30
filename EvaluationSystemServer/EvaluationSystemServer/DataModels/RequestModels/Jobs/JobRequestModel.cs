namespace EvaluationSystemServer
{
    public class JobRequestModel : BaseRequestModel
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

        /// <summary>
        /// The salary
        /// </summary>
        public decimal Salary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobRequestModel() : base()
        {

        }

        #endregion

    }

    public class CreateJobRequestModel : UpdateJobRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateJobRequestModel() : base()
        { 
        
        }

        #endregion
    }

    public class UpdateJobRequestModel : JobRequestModel
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateJobRequestModel() : base()
        {

        }

        #endregion
    }
}
