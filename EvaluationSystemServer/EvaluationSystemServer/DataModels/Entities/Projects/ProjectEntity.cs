using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class ProjectEntity : NormalizedEntity
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        /// <summary>
        /// The member of the <see cref="ProjectCategories"/> property
        /// </summary>
        private ICollection<ProjectCategoryEntity>? mProjectCategories;

        #endregion

        #region Public Properties

        /// <summary>
        /// The description
        /// </summary>
        public string Description
        {
            get => mDescription ?? string.Empty;

            set => mDescription = value;
        }

        /// <summary>
        /// Is the project submitted
        /// </summary>
        public bool IsSubmitted { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public double Grade { get; set; }        

        /// <summary>
        /// The starting date
        /// </summary>
        public DateTimeOffset SubmissionStart { get; set; }

        /// <summary>
        /// The ending date
        /// </summary>
        public DateTimeOffset SubmissionEnd { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="UserEntity"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserEntity"/>
        /// </summary>
        public UserEntity? User { get; set; }

        /// <summary>
        /// The project's categories
        /// </summary>
        public ICollection<ProjectCategoryEntity> ProjectCategories
        { 
            get => mProjectCategories ??= new Collection<ProjectCategoryEntity>();
            
            set => mProjectCategories = value;
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectEntity() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="ProjectEntity"/> from the specified <paramref name="model"/>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ProjectEntity FromRequestModel(ProjectRequestModel model)
            => ControllerHelpers.FromRequestModel<ProjectEntity, ProjectRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="ProjectResponseModel"/> from the current <see cref="ProjectEntity"/>
        /// </summary>
        /// <returns></returns>
        public ProjectResponseModel ToResponseModel()
            => ControllerHelpers.ToResponseModel<ProjectEntity, ProjectResponseModel>(this);

        #endregion

    }
}
