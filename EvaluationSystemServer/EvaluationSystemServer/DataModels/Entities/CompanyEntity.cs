using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class CompanyEntity : BaseEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="DOY"/> property
        /// </summary>
        private string? mDOY;

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        /// <summary>
        /// The member of the <see cref="Phone"/> property
        /// </summary>
        private string? mPhone;

        /// <summary>
        /// The member of the <see cref="Address"/> property
        /// </summary>
        private string? mAddress;

        /// <summary>
        /// The member of the <see cref="City"/> property
        /// </summary>
        private string? mCity;

        /// <summary>
        /// The member of the <see cref="Country"/> property
        /// </summary>
        private string? mCountry;

        /// <summary>
        /// The member of the <see cref="JobPositions"/> property
        /// </summary>
        private ICollection<JobPositionEntity>? mJobPositions;

        /// <summary>
        /// The member of the <see cref="Users"/> property
        /// </summary>
        private ICollection<UserEntity>? mUsers;

        #endregion

        #region Public Properties

        /// <summary>
        /// The AFM
        /// </summary>
        public int AFM { get; set; }   

        /// <summary>
        /// The DOY
        /// </summary>
        public string DOY 
        { 
            get => mDOY ?? string.Empty;
            
            set => mDOY = value;
        } 

        /// <summary>
        /// The name
        /// </summary>
        public string Name 
        { 
            get => mName ?? string.Empty;
            
            set => mName = value;
        }    

        /// <summary>
        /// The phone
        /// </summary>
        public string Phone 
        { 
            get => mPhone ?? string.Empty;
            
            set => mPhone = value;
        }   

        /// <summary>
        /// The website
        /// </summary>
        public Uri? Website { get; set; }

        /// <summary>
        /// The Address
        /// </summary>
        public string Address 
        { 
            get => mAddress ?? string.Empty;
            
            set => mAddress = value;
        }

        /// <summary>
        /// The city
        /// </summary>
        public string City 
        { 
            get => mCity ?? string.Empty;
            
            set => mCity = value;
        }

        /// <summary>
        /// The country
        /// </summary>
        public string Country 
        { 
            get => mCountry ?? string.Empty;
            
            set => mCountry = value;
        }

        #region Relationships

        /// <summary>
        /// The company's users
        /// </summary>
        public ICollection<UserEntity> Users 
        { 
            get => mUsers ??= new Collection<UserEntity>();
            
            set => mUsers = value;
        }  

        /// <summary>
        /// The company's job positions
        /// </summary>
        public ICollection<JobPositionEntity> JobPositions 
        {
            get => mJobPositions ??= new Collection<JobPositionEntity>();
            
            set => mJobPositions = value;
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyEntity() : base()
        {
        
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="CompanyEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        public static CompanyEntity FromRequestModel(CreateCompanyRequestModel model)
            => ControllerHelpers.FromRequestModel<CompanyEntity, CreateCompanyRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="CompanyResponseModel"/> from the current <see cref="CompanyEntity"/>
        /// </summary>
        /// <returns></returns>
        public CompanyResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<CompanyEntity, CompanyResponseModel>(this);


        #endregion
    }
}