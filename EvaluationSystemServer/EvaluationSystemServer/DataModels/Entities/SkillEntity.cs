using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class SkillEntity : BaseEntity
    {

        #region Public Properties

        public string Name { get; set; }

        public string Experience { get; set; }

        #region Relationships

        /// <summary>
        /// The related <see cref="SkillEntity"/>
        /// </summary>
        public IEnumerable<UserSkillEntity> UserSkills { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SkillEntity() 
        { 
        
        }

        #endregion
    }
}
