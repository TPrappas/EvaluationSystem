using Bogus.DataSets;

namespace EvaluationSystemServer
{
    public abstract class NormalizedEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        #endregion

        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;

            set => mName = value;
        }

        /// <summary>
        /// The normalized <see cref="Name"/>
        /// </summary>
        public string NormalizedName
        {
            get => ControllerHelpers.NormalizeString(Name);

            set { }
        } 

        #endregion
    }
}
