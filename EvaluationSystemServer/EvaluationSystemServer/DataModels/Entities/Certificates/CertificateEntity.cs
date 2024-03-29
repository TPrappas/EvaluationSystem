﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class CertificateEntity : NormalizedEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Department"/> property
        /// </summary>
        private string? mDepartment;

        /// <summary>
        /// The member of the <see cref="UserCertificates"/> property
        /// </summary>
        private ICollection<UserCertificateEntity>? mUserCertificates;

        #endregion

        #region Public Properties

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
        public int GraduationYear { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }

        #region Relationships

        /// <summary>
        /// The certificate's employees
        /// </summary>
        public ICollection<UserCertificateEntity> UserCertificates
        { 
            get => mUserCertificates ??= new Collection<UserCertificateEntity>();
            
            set => mUserCertificates = value;
        }

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
        public static CertificateEntity FromRequestModel(CertificateRequestModel model)
            => ControllerHelpers.FromRequestModel<CertificateEntity, CertificateRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CertificateResponseModel"/> from the current <see cref="CertificateEntity"/>
        /// </summary>
        /// <returns></returns>
        public CertificateResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CertificateEntity, CertificateResponseModel>(this);

        #endregion

    }
}
