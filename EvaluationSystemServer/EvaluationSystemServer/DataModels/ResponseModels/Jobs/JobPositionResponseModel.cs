namespace EvaluationSystemServer.DataModels.ResponseModels.Jobs
{
    public class JobPositionResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="JobEntity"/>
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// The related <see cref="JobEntity"/>
        /// </summary>
        public JobEntity Job { get; set; }

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
