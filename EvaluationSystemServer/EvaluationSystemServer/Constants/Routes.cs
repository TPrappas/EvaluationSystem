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

        public const string UserSkillRoute = UserSkillsRoute + "/{userSkillId}";

        #endregion

        #region Project Routes

        public const string ProjectsRoute = HomeRoute + "/projects";

        public const string ProjectRoute = ProjectsRoute + "/{projectId}";

        #endregion

        #region Category Routes

        public const string CategoriesRoute = HomeRoute + "/categories";

        public const string CategoryRoute = CategoriesRoute + "/{categoryId}";

        #endregion

        #region ProjectCategory Routes

        public const string ProjectCategoriesRoute = HomeRoute + "/projectCategories";

        public const string ProjectCategoryRoute = ProjectCategoriesRoute + "/{projectCategoryId}";

        #endregion

        #region Meeting Routes

        public const string MeetingsRoute = HomeRoute + "/meetings";

        public const string MeetingRoute = MeetingsRoute + "/{meetingId}";

        #endregion

        #region ParticipantMeeting Routes

        public const string ParticipantMeetingsRoute = HomeRoute + "/participantMeetings";

        public const string ParticipantMeetingRoute = ParticipantMeetingsRoute + "/{participantMeetingId}";

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

        #region Notification Routes

        public const string NotificationsRoute = HomeRoute + "/notifications";

        public const string NotificationRoute = NotificationsRoute + "/{notificationId}";

        #endregion

        #region License Routes

        public const string LicensesRoute = HomeRoute + "/licenses";

        public const string LicenseRoute = LicensesRoute + "/{licenseId}";

        #endregion

    }
}
