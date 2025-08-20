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

        /// <summary>
        /// Get Admin Route
        /// </summary>
        public static string GetAdminRoute(int adminId) => AdminsRoute + $"/{adminId}";

        #endregion

        #region User Routes

        public const string UsersRoute = HomeRoute + "/users";

        public const string UserRoute = UsersRoute + "/{userId}";

        /// <summary>
        /// Get User Route
        /// </summary>
        public static string GetUserRoute(int userId) => UsersRoute + $"/{userId}"; 

        #endregion

        #region Company Routes

        public const string CompaniesRoute = HomeRoute + "/companies";

        public const string CompanyRoute = CompaniesRoute + "/{companyId}";

        /// <summary>
        /// Get Company Route
        /// </summary>
        public static string GetCompanyRoute(int companyId) => CompaniesRoute + $"/{companyId}";

        #endregion

        #region Certificate Routes

        public const string CertificatesRoute = HomeRoute + "/certificates";

        public const string CertificateRoute = CertificatesRoute + "/{certificateId}";

        /// <summary>
        /// Get Certificate Route
        /// </summary>
        public static string GetCertificateRoute(int certificateId) => CertificatesRoute + $"/{certificateId}";

        #endregion

        #region UserCertificate Routes

        public const string UserCertificatesRoute = HomeRoute + "/userCertificates";

        public const string UserCertificateRoute = UserCertificatesRoute + "/{userCertificateId}";

        /// <summary>
        /// Get User Certificate Route
        /// </summary>
        public static string GetUserCertificateRoute(int certificateId) => UserCertificatesRoute + $"/{certificateId}";

        #endregion

        #region Skill Routes

        public const string SkillsRoute = HomeRoute + "/skills";

        public const string SkillRoute = SkillsRoute + "/{skillId}";

        /// <summary>
        /// Get Skill Route
        /// </summary>
        public static string GetSkillRoute(int skillId) => SkillsRoute + $"/{skillId}";

        #endregion

        #region UserSkill Routes

        public const string UserSkillsRoute = HomeRoute + "/userSkills";

        public const string UserSkillRoute = UserSkillsRoute + "/{userSkillId}";

        /// <summary>
        /// Get User Skill Route
        /// </summary>
        public static string GetUserSkillRoute(int userSkillId) => UserSkillsRoute + $"/{userSkillId}";

        #endregion

        #region Project Routes

        public const string ProjectsRoute = HomeRoute + "/projects";

        public const string ProjectRoute = ProjectsRoute + "/{projectId}";

        /// <summary>
        /// Get Project Route
        /// </summary>
        public static string GetProjectRoute(int projectId) => ProjectsRoute + $"/{projectId}";

        #endregion

        #region Category Routes

        public const string CategoriesRoute = HomeRoute + "/categories";

        public const string CategoryRoute = CategoriesRoute + "/{categoryId}";

        /// <summary>
        /// Get Category Route
        /// </summary>
        public static string GetCategoryRoute(int categoryId) => CategoriesRoute + $"/{categoryId}";

        #endregion

        #region ProjectCategory Routes

        public const string ProjectCategoriesRoute = HomeRoute + "/projectCategories";

        public const string ProjectCategoryRoute = ProjectCategoriesRoute + "/{projectCategoryId}";

        /// <summary>
        /// Get Project Category Route
        /// </summary>
        public static string GetProjectCategoryRoute(int projectCategoryId) => ProjectCategoriesRoute + $"/{projectCategoryId}";

        #endregion

        #region Meeting Routes

        public const string MeetingsRoute = HomeRoute + "/meetings";

        public const string MeetingRoute = MeetingsRoute + "/{meetingId}";

        /// <summary>
        /// Get Meeting Route
        /// </summary>
        public static string GetMeetingRoute(int meetingId) => MeetingsRoute + $"/{meetingId}";

        #endregion

        #region ParticipantMeeting Routes

        public const string ParticipantMeetingsRoute = HomeRoute + "/participantMeetings";

        public const string ParticipantMeetingRoute = ParticipantMeetingsRoute + "/{participantMeetingId}";

        /// <summary>
        /// Get Participant Meeting Route
        /// </summary>
        public static string GetParticipantMeetingRoute(int participantMeetingId) => ParticipantMeetingsRoute + $"/{participantMeetingId}";

        #endregion

        #region Job Routes

        public const string JobsRoute = HomeRoute + "/jobs";

        public const string JobRoute = JobsRoute + "/{jobId}";

        /// <summary>
        /// Get Job Route
        /// </summary>
        public static string GetJobRoute(int jobId) => JobsRoute + $"/{jobId}";

        #endregion

        #region JobPosition Routes

        public const string JobPositionsRoute = HomeRoute + "/jobPositions";

        public const string JobPositionRoute = JobPositionsRoute + "/{jobPositionId}";

        /// <summary>
        /// Get Job Position Route
        /// </summary>
        public static string GetJobPositionRoute(int jobPositionId) => JobPositionsRoute + $"/{jobPositionId}";

        #endregion

        #region JobApplication Routes

        public const string JobApplicationsRoute = HomeRoute + "/jobApplications";

        public const string JobApplicationRoute = JobApplicationsRoute + "/{jobApplicationId}";

        /// <summary>
        /// Get Job Application Route
        /// </summary>
        public static string GetJobApplicationRoute(int jobApplicationId) => JobApplicationsRoute + $"/{jobApplicationId}";

        #endregion

    }
}
