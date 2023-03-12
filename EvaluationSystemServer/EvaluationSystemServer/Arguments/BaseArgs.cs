namespace EvaluationSystemServer
{
    public class BaseArgs
    {
        #region Public Properties

        public int Page { get; set; } = 0;

        public int PerPage { get; set; } = 10;

        #endregion

        #region Constructors

        public BaseArgs()
        {

        }

        #endregion
    }
}
