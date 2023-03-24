namespace EvaluationSystemServer
{
    public class JobPositionResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="JobResponseModel"/>
        /// </summary>
        public EmbeddedJobResponseModel Job { get; set; }

        /// <summary>
        /// Is the position open or closed
        /// </summary>
        public bool IsOpen { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionResponseModel() : base()
        {

        }

        #endregion
    }

    public class EmbeddedJobPositionResponseModel : JobPositionResponseModel 
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedJobPositionResponseModel() : base()
        {

        }

        #endregion
    }
}
