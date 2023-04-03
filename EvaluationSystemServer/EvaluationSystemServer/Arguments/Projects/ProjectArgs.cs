﻿namespace EvaluationSystemServer
{
    public class ProjectArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="IncludeUsers"/> property
        /// </summary>
        private IEnumerable<int>? mIncludeUsers;

        /// <summary>
        /// The member of the <see cref="ExcludeUsers"/> property
        /// </summary>
        private IEnumerable<int>? mExcludeUsers;

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
        /// By minGrade
        /// </summary>
        public double? MinGrade { get; set; }

        /// <summary>
        /// By maxGrade
        /// </summary>
        public double? MaxGrade { get; set; }

        /// <summary>
        /// Is the project submitted
        /// </summary>
        public bool? IsSubmitted { get; set; }

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

        /// <summary>
        /// User included
        /// </summary>
        public IEnumerable<int> IncludeUsers 
        { 
            get => mIncludeUsers ?? Enumerable.Empty<int>();
            
            set => mIncludeUsers = value;
        }

        /// <summary>
        /// User excluded
        /// </summary>
        public IEnumerable<int> ExcludeUsers
        {
            get => mExcludeUsers ?? Enumerable.Empty<int>();

            set => mExcludeUsers = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectArgs()
        {

        }

        #endregion
    }
}
