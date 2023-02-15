using Microsoft.AspNetCore.Mvc;

namespace EvaluationSystemServer
{
    public class UserController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserController(EvaluationSystemDBContext context) 
        { 
            mContext = context;
        }

        #endregion

        #region Public Methods


        #endregion
    }
}
