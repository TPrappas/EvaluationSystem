﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class CategoryController : Controller
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
        public CategoryController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// Post api/categories
        [HttpPost]
        [Route(Routes.CategoriesRoute)]
        public Task<ActionResult<CategoryResponseModel>> CreateCategoryAsync([FromBody] CategoryRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Categories,
                CategoryEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the categories from the database
        /// </summary>
        /// Get api/categories
        [HttpGet]
        [Route(Routes.CategoriesRoute)]
        public Task<ActionResult<IEnumerable<CategoryResponseModel>>> GetCategoriesAsync() =>
            // Gets the response models for each project entity
            ControllerHelpers.GetAllAsync<CategoryEntity, CategoryResponseModel>(
                mContext.Categories,
                x => true);

        /// <summary>
        /// Gets the project with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="categoryId">The category's id</param>
        /// Get api/categories/{categoriesId} == api/categories/1
        [HttpGet]
        [Route(Routes.CategoryRoute)]
        public Task<ActionResult<CategoryResponseModel>> GetCategoryAsync([FromRoute] int categoryId)
        {
            // The needed expression for the filter
            Expression<Func<CategoryEntity, bool>> filter = x => x.Id == categoryId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<CategoryEntity, CategoryResponseModel>(
                mContext.Categories,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the user with the specified id
        /// </summary>
        /// <param name="categoryId">The catrgory's id</param>
        /// <param name="model">The project request model</param>
        /// Put /api/categories/{categoryId}
        [HttpPut]
        [Route(Routes.CategoryRoute)]
        public Task<ActionResult<CategoryResponseModel>> UpdateCategoryAsync([FromRoute] int categoryId, [FromBody] CategoryRequestModel model)
        {
            return ControllerHelpers.PutAsync<CategoryRequestModel, CategoryEntity, CategoryResponseModel>(
                mContext,
                mContext.Categories,
                model,
                x => x.Id == categoryId);
        }

        /// <summary>
        /// Deletes the user with the specified id if exists from the database
        /// </summary>
        /// <param name="categoryId">The project's id</param>
        /// Delete /api/categories/{categoryId}
        [HttpDelete]
        [Route(Routes.ProjectRoute)]
        public Task<ActionResult<CategoryResponseModel>> DeleteCategoryAsync(int categoryId)
        {
            return ControllerHelpers.DeleteAsync<CategoryEntity, CategoryResponseModel>(
                mContext,
                mContext.Categories,
                DI.GetMapper,
                x => x.Id == categoryId);
        }

        #endregion
    }
}