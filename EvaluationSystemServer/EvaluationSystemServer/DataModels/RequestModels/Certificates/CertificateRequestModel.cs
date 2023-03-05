namespace EvaluationSystemServer.DataModels.RequestModels.Certificates
{
    public class CertificateRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// The graduation year
        /// </summary>
        public double GradutationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        public CertificateRequestModel()
        {

        }

        #endregion

    }
}
