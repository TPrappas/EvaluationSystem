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
        /// The user's projects
        /// </summary>
        public DbSet<ProjectEntity> Projects { get; set; }

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

        /// <summary>
        /// The applications
        /// </summary>
        public DbSet<JobApplicationEntity> Applications { get; set; }

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
                .HasMany(x => x.Applications)
                // Each leaflet one user (employee)
                .WithOne(x => x.User)
                // The principal key of the join is the UserEntity.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the ApplicationEntity.EmployeeId (UserId)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.EmployeeProjects)
                .WithOne(x => x.Employee)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

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

            #region Companies

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id) 
                .HasForeignKey(x=> x.CompanyId)
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

            #endregion

        }

        #endregion

    }
}
