namespace EvaluationSystemServer
{
    public class JobApplicationArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="IncludeManagers"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeManagers;

        /// <summary>
        /// The member of the <see cref="ExcludeManagers"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeManagers;

        /// <summary>
        /// The member of the <see cref="IncludeEvaluators"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeEvaluators;

        /// <summary>
        /// The member of the <see cref="ExcludeEvaluators"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeEvaluators;

        /// <summary>
        /// The member of the <see cref="IncludeEmployees"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeEmployees;

        /// <summary>
        /// The member of the <see cref="ExcludeEmployees"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeEmployees;

        #endregion

        #region Public Methods

        /// <summary>
        /// Manager included
        /// </summary>
        public IEnumerable<int> IncludeManagers 
        { 
            get => mIncludeManagers ?? Enumerable.Empty<int>();
            
            set => mIncludeManagers = value;
        }

        /// <summary>
        /// Manager excluded
        /// </summary>
        public IEnumerable<int> ExcludeManagers 
        {
            get => mExcludeManagers ?? Enumerable.Empty<int>();
            
            set => mExcludeManagers = value; 
        }

        /// <summary>
        /// Evaluator included
        /// </summary>
        public IEnumerable<int> IncludeEvaluators 
        { 
            get => mIncludeEvaluators ?? Enumerable.Empty<int>();
            
            set => mIncludeEvaluators = value;
        }

        /// <summary>
        /// Evaluator excluded
        /// </summary>
        public IEnumerable<int> ExcludeEvaluators 
        { 
            get => mExcludeEvaluators ?? Enumerable.Empty<int>();
            
            set => mExcludeEvaluators = value; 
        }

        /// <summary>
        /// Employee included
        /// </summary>
        public IEnumerable<int> IncludeEmployees 
        {
            get => mIncludeEmployees ?? Enumerable.Empty<int>();
            
            set => mIncludeEmployees = value;
        }

        /// <summary>
        /// Employee excluded
        /// </summary>
        public IEnumerable<int> ExcludeEmployees 
        { 
            get => mExcludeEmployees ?? Enumerable.Empty<int>(); 
            
            set => mExcludeEmployees = value;
        }

        /// <summary>
        /// By minGrade
        /// </summary>
        public double? MinGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? MaxGrade { get; set; }


        /// <summary>
        /// After submission start
        /// </summary>
        public DateTimeOffset? AfterSubmissionStart { get; set; }

        /// <summary>
        /// Before submission start
        /// </summary>
        public DateTimeOffset? BeforeSubmissionStart { get; set; }

        /// <summary>
        /// After submission end
        /// </summary>
        public DateTimeOffset? AfterSubmissionEnd { get; set; }

        /// <summary>
        /// Before submission end
        /// </summary>
        public DateTimeOffset? BeforeSubmissionEnd { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobApplicationArgs()
        {

        }

        #endregion

    }
}
