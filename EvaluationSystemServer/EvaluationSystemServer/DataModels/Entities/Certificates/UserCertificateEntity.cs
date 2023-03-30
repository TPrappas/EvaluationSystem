using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class UserCertificateEntity : BaseEntity
    {
        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity? User { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CertificateEntity"/>
        /// </summary>
        public int CertificateId { get; set; }

        /// <summary>
        /// The related <see cref="CertificateEntity"/>
        /// </summary>
        public CertificateEntity? Certificate { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserCertificateEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="UserCertificateResponseModel"/> from the current <see cref="UserCertificateEntity"/>
        /// </summary>
        /// <returns></returns>
        public UserCertificateResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<UserCertificateEntity, UserCertificateResponseModel>(this);

        #endregion

    }
}
