using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{ 
    public class CertificateEntity : BaseEntity
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

        #region Relationships

        /// <summary>
        /// The certificate's employees
        /// </summary>
        public IEnumerable<UserCertificateEntity> UserCertificates { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public CertificateEntity()
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CertificateEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CertificateEntity FromRequestModel(CertificateRequestModel model)
            => ControllerHelpers.FromRequestModel<CertificateEntity, CertificateRequestModel>(model);

        #endregion

    }
}
