using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class AdminEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }    

        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AdminEntity() 
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

        #endregion
    }
}
