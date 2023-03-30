using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class AdminEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Username"/> property
        /// </summary>
        private string? mUsername;

        /// <summary>
        /// The member of the <see cref="Password"/> property
        /// </summary>
        private string? mPassword;

        #endregion

        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username 
        { 
            get => mUsername ?? string.Empty;
            
            set => mUsername = value; 
        }    

        /// <summary>
        /// The password
        /// </summary>
        public string Password
        { 
            get => mPassword ?? string.Empty;
            
            set => mPassword = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AdminEntity() : base()
        {
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="AdminEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AdminEntity FromRequestModel(AdminRequestModel model)
            => ControllerHelpers.FromRequestModel<AdminEntity, AdminRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="AdminResponseModel"/> from the current <see cref="AdminEntity"/>
        /// </summary>
        /// <returns></returns>
        public AdminResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<AdminEntity, AdminResponseModel>(this);

        #endregion
    }
}
