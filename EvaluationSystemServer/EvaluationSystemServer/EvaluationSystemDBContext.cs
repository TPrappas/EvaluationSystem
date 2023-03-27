using Microsoft.EntityFrameworkCore;

namespace EvaluationSystemServer
{
    /// <summary>
    /// Database structure
    /// </summary>
    public class EvaluationSystemDBContext : DbContext
    {
        #region Public Properties 

        /// <summary>
        /// The admins
        /// </summary>
        public DbSet<AdminEntity> Admins { get; set; }  

        /// <summary>
        /// The users
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// The companies
        /// </summary>
        public DbSet<CompanyEntity> Companies { get; set; }

        /// <summary>
        /// The skills
        /// </summary>
        public DbSet<SkillEntity> Skills { get; set; }

        /// <summary>
        /// The user's skills
        /// </summary>
        public DbSet<UserSkillEntity> UserSkills { get; set; }

        /// <summary>
        /// The certificates
        /// </summary>
        public DbSet<CertificateEntity> Certificates { get; set; }

        /// <summary>
        /// The user's certificates
        /// </summary>
        public DbSet<UserCertificateEntity> UserCertificates { get; set; }

        /// <summary>
        /// The projects
        /// </summary>
        public DbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// The project's categories
        /// </summary>
        public DbSet<ProjectCategoryEntity> ProjectCategories { get; set; }

        /// <summary>
        /// The categories
        /// </summary>
        public DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// The meetings
        /// </summary>
        public DbSet<MeetingEntity> Meetings { get; set; }

        /// <summary>
        /// The participant's meetings
        /// </summary>
        public DbSet<ParticipantMeetingEntity> ParticipantMeetings { get; set; }

        /// <summary>
        /// The jobs
        /// </summary>
        public DbSet<JobEntity> Jobs { get; set; }

        /// <summary>
        /// The job positions
        /// </summary>
        public DbSet<JobPositionEntity> JobPositions { get; set; }

        /// <summary>
        /// The job applications
        /// </summary>
        public DbSet<JobApplicationEntity> JobApplications { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public EvaluationSystemDBContext(DbContextOptions<EvaluationSystemDBContext> options) : base(options)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
        /// to discover any changes to entity instances before saving to the underlying database.
        /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
        /// Multiple active operations on the same context instance are not supported. Use
        /// 'await' to ensure that any asynchronous operations have completed before calling
        /// another method on this context.
        /// </summary>
        /// <param name="cancellationToken">
        /// A System.Threading.CancellationToken to observe while waiting for the task to
        /// complete.
        /// </param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(true, true, cancellationToken);
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
        /// to discover any changes to entity instances before saving to the underlying database.
        /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
        /// Multiple active operations on the same context instance are not supported. Use
        /// 'await' to ensure that any asynchronous operations have completed before calling
        /// another method on this context.
        /// </summary>
        /// <param name="shouldUpdateCreationDates">
        /// A flag indicating whether the creation dates should be updated for the models that implement the <see cref="IDateCreatable"/>
        /// interfaces
        /// </param>
        /// <param name="shouldUpdateModificationDates">
        /// A flag indicating whether the modification dates should be updated for the models that implement the <see cref="IDateModifiable"/>
        /// interfaces
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to
        /// complete.
        /// </param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(bool shouldUpdateCreationDates, bool shouldUpdateModificationDates, CancellationToken cancellationToken = default)
        {
            if (shouldUpdateCreationDates)
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                    if (entry.State == EntityState.Added)
                        entry.Entity.DateCreated = DateTimeOffset.Now;
            }

            if (shouldUpdateModificationDates)
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        entry.Entity.DateUpdated = DateTimeOffset.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="DbSet{TEntity}"/> properties
        /// on your derived context. The resulting model may be cached and re-used for subsequent
        /// instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Users

            // For the applications of a user (employee)
            modelBuilder.Entity<UserEntity>()
                // One user (employee) has many applications
                .HasMany(x => x.EmployeeApplications)
                // Each leaflet one user (employee)
                .WithOne(x => x.Employee)
                // The principal key of the join is the UserEntity.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the ApplicationEntity.EmployeeId (UserId)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.ManagerApplications)
                .WithOne(x => x.Manager)
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.EvaluatorApplications)
                .WithOne(x => x.Evaluator)
                .HasForeignKey(x => x.EvaluatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.OrganizersMeeting)
                .WithOne(x => x.Organizer)
                .HasForeignKey(x => x.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region User Skills

            // For the user-skills of a user
            modelBuilder.Entity<UserSkillEntity>()
                // Many user-skills have one user
                .HasOne(x => x.User)
                // Each user has many skills
                .WithMany(x => x.UserSkills)
                // The principal key of the join is the UserSkillEntity.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the UserSkillEntity.UserId
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSkillEntity>()
                .HasOne(x => x.Skill)
                .WithMany(x => x.UserSkills)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region User Certificates

            modelBuilder.Entity<UserCertificateEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserCertificates)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCertificateEntity>()
                .HasOne(x => x.Certificate)
                .WithMany(x => x.UserCertificates)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Participant Meetings

            modelBuilder.Entity<ParticipantMeetingEntity>()
                 .HasOne(x => x.Participant)
                 .WithMany(x => x.ParticipantsMeeting)
                 .HasPrincipalKey(x => x.Id)
                 .HasForeignKey(x => x.ParticipantId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParticipantMeetingEntity>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.ParticipantMeetings)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Companies

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.JobPositions)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id) 
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Project Categories

            modelBuilder.Entity<ProjectCategoryEntity>()
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectCategories)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectCategoryEntity>()
                .HasOne(x => x.Category)
                .WithMany(x => x.ProjectsCategory)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Jobs

            modelBuilder.Entity<JobEntity>()
                .HasMany(x => x.JobPositions)
                .WithOne(x => x.Job)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Job Positions

            modelBuilder.Entity<JobPositionEntity>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.JobPosition)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.JobPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobPositionEntity>()
                .HasMany(x => x.JobApplications)
                .WithOne(x => x.JobPosition)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.JobPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

        }

        #endregion

    }
}
