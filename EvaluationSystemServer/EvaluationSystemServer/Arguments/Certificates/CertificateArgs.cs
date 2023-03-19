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
        public double? MinGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? MaxGrade { get; set; }

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
