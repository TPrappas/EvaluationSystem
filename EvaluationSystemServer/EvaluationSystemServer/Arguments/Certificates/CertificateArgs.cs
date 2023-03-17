namespace EvaluationSystemServer
{
    public class CertificateArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// By minGrade
        /// </summary>
        public double? minGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? maxGrade { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CertificateArgs()
        {

        }

        #endregion
    }
}
