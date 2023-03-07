namespace EvaluationSystemServer
{
    public class JobPositionResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The related <see cref="JobResponseModel"/>
        /// </summary>
        public JobResponseModel Job { get; set; }

        /// <summary>
        /// Is the position open or closed
        /// </summary>
        public bool IsOpen { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionResponseModel()
        {

        }

        #endregion

    }
}
