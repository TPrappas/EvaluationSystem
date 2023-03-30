using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class CertificateEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Department"/> property
        /// </summary>
        private string? mDepartment;

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
        /// The department
        /// </summary>
        public string Department 
        { 
            get => mDepartment ?? string.Empty; 
            
            set => mDepartment = value;
        }

        /// <summary>
        /// The graduation year
        /// </summary>
        public double GradugtationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        #region Relationships

        /// <summary>
        /// The certificate's employees
        /// </summary>
        public IEnumerable<UserCertificateEntity>? UserCertificates { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public CertificateEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CertificateEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CertificateEntity FromRequestModel(CreateCertificateRequestModel model)
            => ControllerHelpers.FromRequestModel<CertificateEntity, CreateCertificateRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CertificateResponseModel"/> from the current <see cref="CertificateEntity"/>
        /// </summary>
        /// <returns></returns>
        public CertificateResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CertificateEntity, CertificateResponseModel>(this);

        #endregion

    }
}
