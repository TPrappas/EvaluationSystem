namespace EvaluationSystemServer
{
    public class CertificateArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// Limit the result to entries using a string
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Limit the result set to entries with specific departments
        /// </summary>
        public IEnumerable<string>? IncludeDepartments { get; set; }

        /// <summary>
        /// Limit the result set to entries without specific departments
        /// </summary>
        public IEnumerable<string>? ExcludeDepartments { get; set; }

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
        public CertificateArgs() : base() 
        {

        }

        #endregion
    }
}
