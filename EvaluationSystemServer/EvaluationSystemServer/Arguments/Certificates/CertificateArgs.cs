namespace EvaluationSystemServer
{
    public class CertificateArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="Department"/> property
        /// </summary>
        private string? mDepartment;

        #endregion

        #region Public Properties

        /// <summary>
        /// By name
        /// </summary>
        public string Search 
        { 
            get => mSearch ?? string.Empty; 
            
            set => mSearch = value;
        }

        /// <summary>
        /// By department
        /// </summary>
        public string Department 
        { 
            get => mDepartment ?? string.Empty;
            
            set => mDepartment = value;
        }

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
