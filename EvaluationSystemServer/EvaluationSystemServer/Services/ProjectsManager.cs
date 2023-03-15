using Microsoft.EntityFrameworkCore;

namespace EvaluationSystemServer
{
    public class ProjectsManager
    {
        #region Public Methods

        public async Task<ProjectEntity> AddProjectAsync(ProjectRequestModel model)
        {
            // Get the database context
            var dbContext = DI.GetDbContext;

            // Create the project
            var project = DI.GetMapper.Map<ProjectEntity>(model);

            // Add it to the database
            dbContext.Projects.Add(project);

            // Save the changes to get a project id
            await dbContext.SaveChangesAsync();

            // If there are project categories...
            if (model.Categories is not null)
            {
                // For every category id...
                foreach (var id in model.Categories)
                    // Add the category
                    dbContext.ProjectCategories.Add(new ProjectCategoryEntity() { CategoryId = id, ProjectId = project.Id });

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // Return the project
            return project;
        }

        public async Task<ProjectEntity> UpdateProjectAsync(int id, ProjectRequestModel model)
        {
            // Get the database context
            var dbContext = DI.GetDbContext;

            // Get the project
            var project = await dbContext.Projects.FirstAsync(x => x.Id == id);

            // Update the values that can be updated using the AutoMapper
            DI.GetMapper.Map(model, project);

            // Save the changes
            await dbContext.SaveChangesAsync();

            // If there are project categories...
            if (model.Categories is not null)
            {
                // Get the existing project categories
                var existingProjectCategories = await dbContext.ProjectCategories.Where(x => x.ProjectId == project.Id).ToListAsync();

                // For every existing project category...
                foreach (var existingProjectCategory in existingProjectCategories)
                {
                    // If it is not contained in the requested ids...
                    if (model.Categories.Any(x => x == existingProjectCategory.CategoryId))
                        // Remove it
                        dbContext.ProjectCategories.Remove(existingProjectCategory);
                }

                // For every certificate id...
                foreach (var categoryId in model.Categories)
                {
                    // If there isn't a project category with that id...
                    if (!existingProjectCategories.Any(x => x.CategoryId == categoryId))
                        // Add the category
                        dbContext.ProjectCategories.Add(new ProjectCategoryEntity() { CategoryId = id, ProjectId = project.Id });
                }

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // Return the project
            return project;
        }

        #endregion
    }
}
