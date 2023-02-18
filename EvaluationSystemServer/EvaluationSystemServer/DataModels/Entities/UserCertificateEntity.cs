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
        public UserEntity User { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="CertificateEntity"/>
        /// </summary>
        public int CertificateId { get; set; }

        /// <summary>
        /// The related <see cref="CertificateEntity"/>
        /// </summary>
        public CertificateEntity Certificate { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserCertificateEntity() 
        { 
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="UserCertificateEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <param name="certificateId">The certificate's id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserCertificateEntity FromRequestModel(int userId, int certificateId, UserCertificateEntity model)
            => ControllerHelpers.FromRequestModel(model, (UserCertificateEntity entity) => { entity.UserId = userId; entity.CertificateId = certificateId; });

        #endregion

    }
}
