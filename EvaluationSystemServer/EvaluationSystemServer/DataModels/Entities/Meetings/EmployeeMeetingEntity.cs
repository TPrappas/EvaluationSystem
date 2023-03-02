using EvaluationSystemServer;

namespace EvaluationSystemServerngs
{
    public class EmployeeMeetingEntity : BaseEntity
    {

        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity Employee { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="MeetingEntity"/>
        /// </summary>
        public int MeetingId { get; set; }

        /// <summary>
        /// The related <see cref="Meeting"/>
        /// </summary>
        public MeetingEntity Meeting { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeMeetingEntity() 
        { 
        
        }

        #endregion


    }
}
