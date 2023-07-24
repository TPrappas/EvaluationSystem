namespace EvaluationSystemServer
{
    public class NotificationArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By notification type
        /// </summary>
        public NotificationType? NotificationType { get; set; }

        /// <summary>
        /// Users included
        /// </summary>
        public IEnumerable<int>? IncludeUsers { get; set; }

        /// <summary>
        /// Exclude excluded
        /// </summary>
        public IEnumerable<int>? ExcludeUsers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NotificationArgs() : base()
        {

        }

        #endregion
    }
}
