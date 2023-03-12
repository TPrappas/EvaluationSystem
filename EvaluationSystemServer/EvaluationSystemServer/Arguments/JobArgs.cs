namespace EvaluationSystemServer
{
    public class JobArgs : BaseArgs
    {
        #region Public Properties

        public string Search { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public DateTimeOffset? AfterDateCreated { get; set; }

        public DateTimeOffset? BeforeDateCreated { get; set; }

        public IEnumerable<int> IncludeCompanies { get; set; }

        public IEnumerable<int> ExcludeCompanies { get; set; }

        #endregion
    }
}
