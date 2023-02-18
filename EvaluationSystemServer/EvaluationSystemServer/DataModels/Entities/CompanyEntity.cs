using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class CompanyEntity : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// The AFM
        /// </summary>
        public int AFM { get; set; }   

        /// <summary>
        /// The DOY
        /// </summary>
        public string DOY { get; set; } 

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }    

        /// <summary>
        /// The phone
        /// </summary>
        public string Phone { get; set; }   

        /// <summary>
        /// The website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// The Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; set; }

        #region Relationships

        /// <summary>
        /// The company's users
        /// </summary>
        public IEnumerable<UserEntity> Users { get; set; }  

        /// <summary>
        /// The company's jobs
        /// </summary>
        public IEnumerable<JobEntity> Jobs { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyEntity() 
        {
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CompanyEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CompanyEntity FromRequestModel(CompanyRequestModel model)
            => ControllerHelpers.FromRequestModel<CompanyEntity, CompanyRequestModel>(model);



        #endregion
    }
}