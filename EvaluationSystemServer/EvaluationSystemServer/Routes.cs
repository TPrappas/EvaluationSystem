namespace EvaluationSystemServer
{
    /// <summary>
    /// The string that represent the API routes
    /// </summary>
    public class Routes
    {
        /// <summary>
        /// The home route
        /// </summary>
        public const string HomeRoute = "api";

        #region Admin Routes

        public const string AdminsRoute = HomeRoute + "/admins";

        public const string AdminRoute = AdminsRoute + "/{adminId}";

        #endregion

        #region User Routes

        public const string UsersRoute = HomeRoute + "/users";

        public const string UserRoute = UsersRoute + "/{userId}";

        #endregion

        #region Company Routes

        public const string CompaniesRoute = HomeRoute + "/companies";

        public const string CompanyRoute = CompaniesRoute + "/{companyId}";

        #endregion

        #region Certificate Routes

        public const string CertificatesRoute = HomeRoute + "/certificates";

        public const string CertificateRoute = CertificatesRoute + "/{certificateId}";

        #endregion

        #region UserCertificate Routes

        public const string UserCertificatesRoute = HomeRoute + "/userCertificates";

        public const string UserCertificateRoute = UserCertificatesRoute + "/{userCertificateId}";

        #endregion

        #region Skill Routes

        public const string SkillsRoute = HomeRoute + "/skills";

        public const string SkillRoute = SkillsRoute + "/{skillId}";

        #endregion

        #region UserSkill Routes

        public const string UserSkillsRoute = HomeRoute + "/userSkills";

        public const string UserSkillRoute = UserSkillsRoute + "/{userSkillsId}";

        #endregion

        #region Project Routes

        public const string ProjectsRoute = HomeRoute + "/projects";

        public const string ProjectRoute = ProjectsRoute + "/{projectId}";

        #endregion

        #region Job Routes

        public const string JobsRoute = HomeRoute + "/jobs";

        public const string JobRoute = JobsRoute + "/{jobId}";

        #endregion

        #region JobPosition Routes

        public const string JobPositionsRoute = HomeRoute + "/jobPositions";

        public const string JobPositionRoute = JobPositionsRoute + "/{jobPositionId}";

        #endregion

        #region JobApplication Routes

        public const string JobApplicationsRoute = HomeRoute + "/jobApplications";

        public const string JobApplicationRoute = JobApplicationsRoute + "/{jobApplicationId}";

        #endregion

    }
}
