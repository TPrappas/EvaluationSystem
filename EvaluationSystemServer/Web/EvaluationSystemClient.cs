using EvaluationSystemServer;
using Newtonsoft.Json;
using System.Text;

namespace Web
{
    public class EvaluationSystemClient 
    {
        private readonly EvaluationSystemWebRequestClient mClient = new();

        #region Admin

        public async Task<WebRequestResult<AdminResponseModel>> GetAdminAsync(int id)
            => await mClient.GetAsync<AdminResponseModel>(GetAbsoluteUrl(Routes.GetAdminRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<AdminResponseModel>> PostAdminAsync(AdminRequestModel model)
            => await mClient.PostAsync<AdminResponseModel>(GetAbsoluteUrl(Routes.AdminsRoute), model, null);

        public async Task<WebRequestResult<AdminResponseModel>> UpdateAdminAsync(int id, UpdateAdminRequestModel model)
            => await mClient.PutAsync<AdminResponseModel>(GetAbsoluteUrl(Routes.GetAdminRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<AdminResponseModel>> DeleteAdminAsync(int id)
            => await mClient.DeleteAsync<AdminResponseModel>(GetAbsoluteUrl(Routes.GetAdminRoute(id)), null, CancellationToken.None);

        #endregion

        #region User

        public async Task<WebRequestResult<UserResponseModel>> GetUserAsync(int id)
            => await mClient.GetAsync<UserResponseModel>(GetAbsoluteUrl(Routes.GetUserRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<UserResponseModel>> PostUserAsync(UserRequestModel model)
            => await mClient.PostAsync<UserResponseModel>(GetAbsoluteUrl(Routes.UsersRoute), model, null);

        public async Task<WebRequestResult<UserResponseModel>> UpdateUserAsync(int id, UpdateUserRequestModel model)
            => await mClient.PutAsync<UserResponseModel>(GetAbsoluteUrl(Routes.GetUserRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<UserResponseModel>> DeleteUserAsync(int id)
            => await mClient.DeleteAsync<UserResponseModel>(GetAbsoluteUrl(Routes.GetUserRoute(id)), null, CancellationToken.None);

        #endregion

        #region Company

        public async Task<WebRequestResult<CompanyResponseModel>> GetCompanyAsync(int id)
            => await mClient.GetAsync<CompanyResponseModel>(GetAbsoluteUrl(Routes.GetCompanyRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<CompanyResponseModel>> PostCompanyAsync(CompanyRequestModel model)
            => await mClient.PostAsync<CompanyResponseModel>(GetAbsoluteUrl(Routes.CompaniesRoute), model, null);

        public async Task<WebRequestResult<CompanyResponseModel>> UpdateCompanyAsync(int id, UpdateCompanyRequestModel model)
            => await mClient.PutAsync<CompanyResponseModel>(GetAbsoluteUrl(Routes.GetCompanyRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<CompanyResponseModel>> DeleteCompanyAsync(int id)
            => await mClient.DeleteAsync<CompanyResponseModel>(GetAbsoluteUrl(Routes.GetCompanyRoute(id)), null, CancellationToken.None);

        #endregion

        #region Certificate

        public async Task<WebRequestResult<CertificateResponseModel>> GetCertificateAsync(int id)
            => await mClient.GetAsync<CertificateResponseModel>(GetAbsoluteUrl(Routes.GetCertificateRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<CertificateResponseModel>> PostCertificateAsync(CertificateRequestModel model)
            => await mClient.PostAsync<CertificateResponseModel>(GetAbsoluteUrl(Routes.CertificatesRoute), model, null);

        public async Task<WebRequestResult<CertificateResponseModel>> UpdateCertificateAsync(int id, UpdateCertificateRequestModel model)
            => await mClient.PutAsync<CertificateResponseModel>(GetAbsoluteUrl(Routes.GetCertificateRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<CertificateResponseModel>> DeleteCertificateAsync(int id)
            => await mClient.DeleteAsync<CertificateResponseModel>(GetAbsoluteUrl(Routes.GetCertificateRoute(id)), null, CancellationToken.None);

        #endregion

        #region UserCertificate

        public async Task<WebRequestResult<UserCertificateResponseModel>> GetUserCertificateAsync(int id)
            => await mClient.GetAsync<UserCertificateResponseModel>(GetAbsoluteUrl(Routes.GetUserCertificateRoute(id)), null, CancellationToken.None);

        #endregion

        #region Skill

        public async Task<WebRequestResult<SkillResponseModel>> GetSkillAsync(int id)
            => await mClient.GetAsync<SkillResponseModel>(GetAbsoluteUrl(Routes.GetSkillRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<SkillResponseModel>> PostSkillAsync(SkillRequestModel model)
            => await mClient.PostAsync<SkillResponseModel>(GetAbsoluteUrl(Routes.SkillsRoute), model, null);

        public async Task<WebRequestResult<SkillResponseModel>> UpdateSkillAsync(int id, UpdateSkillRequestModel model)
            => await mClient.PutAsync<SkillResponseModel>(GetAbsoluteUrl(Routes.GetSkillRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<SkillResponseModel>> DeleteSkillAsync(int id)
            => await mClient.DeleteAsync<SkillResponseModel>(GetAbsoluteUrl(Routes.GetSkillRoute(id)), null, CancellationToken.None);

        #endregion

        #region UserSkill

        public async Task<WebRequestResult<UserSkillResponseModel>> GetUserSkillAsync(int id)
            => await mClient.GetAsync<UserSkillResponseModel>(GetAbsoluteUrl(Routes.GetUserSkillRoute(id)), null, CancellationToken.None);

        #endregion

        #region Project

        public async Task<WebRequestResult<ProjectResponseModel>> GetProjectAsync(int id)
            => await mClient.GetAsync<ProjectResponseModel>(GetAbsoluteUrl(Routes.GetProjectRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<ProjectResponseModel>> PostProjectAsync(ProjectRequestModel model)
            => await mClient.PostAsync<ProjectResponseModel>(GetAbsoluteUrl(Routes.ProjectsRoute), model, null);

        public async Task<WebRequestResult<ProjectResponseModel>> UpdateProjectAsync(int id, UpdateProjectRequestModel model)
            => await mClient.PutAsync<ProjectResponseModel>(GetAbsoluteUrl(Routes.GetProjectRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<ProjectResponseModel>> DeleteProjectAsync(int id)
            => await mClient.DeleteAsync<ProjectResponseModel>(GetAbsoluteUrl(Routes.GetProjectRoute(id)), null, CancellationToken.None);


        #endregion

        #region Category

        public async Task<WebRequestResult<CategoryResponseModel>> GetCategoryAsync(int id)
            => await mClient.GetAsync<CategoryResponseModel>(GetAbsoluteUrl(Routes.GetCategoryRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<CategoryResponseModel>> PostCategoryAsync(CategoryRequestModel model)
            => await mClient.PostAsync<CategoryResponseModel>(GetAbsoluteUrl(Routes.CategoriesRoute), model, null);

        public async Task<WebRequestResult<CategoryResponseModel>> UpdateCategoryAsync(int id, UpdateCategoryRequestModel model)
            => await mClient.PutAsync<CategoryResponseModel>(GetAbsoluteUrl(Routes.GetCategoryRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<CategoryResponseModel>> DeleteCategoryAsync(int id)
            => await mClient.DeleteAsync<CategoryResponseModel>(GetAbsoluteUrl(Routes.GetCategoryRoute(id)), null, CancellationToken.None);

        #endregion

        #region ProjectCategory

        public async Task<WebRequestResult<ProjectCategoryResponseModel>> GetProjectCategoryAsync(int id)
            => await mClient.GetAsync<ProjectCategoryResponseModel>(GetAbsoluteUrl(Routes.GetProjectCategoryRoute(id)), null, CancellationToken.None);

        #endregion

        #region Meeting

        public async Task<WebRequestResult<MeetingResponseModel>> GetMeetingAsync(int id)
            => await mClient.GetAsync<MeetingResponseModel>(GetAbsoluteUrl(Routes.GetMeetingRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<MeetingResponseModel>> PostMeetingAsync(MeetingRequestModel model)
            => await mClient.PostAsync<MeetingResponseModel>(GetAbsoluteUrl(Routes.MeetingsRoute), model, null);

        public async Task<WebRequestResult<MeetingResponseModel>> UpdateMeetingAsync(int id, UpdateMeetingRequestModel model)
            => await mClient.PutAsync<MeetingResponseModel>(GetAbsoluteUrl(Routes.GetMeetingRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<MeetingResponseModel>> DeleteMeetingAsync(int id)
            => await mClient.DeleteAsync<MeetingResponseModel>(GetAbsoluteUrl(Routes.GetMeetingRoute(id)), null, CancellationToken.None);

        #endregion

        #region ParticipantMeeting

        public async Task<WebRequestResult<ParticipantMeetingResponseModel>> GetParticipantMeetingAsync(int id)
            => await mClient.GetAsync<ParticipantMeetingResponseModel>(GetAbsoluteUrl(Routes.GetParticipantMeetingRoute(id)), null, CancellationToken.None);

        #endregion

        #region Job

        public async Task<WebRequestResult<JobResponseModel>> GetJobAsync(int id)
            => await mClient.GetAsync<JobResponseModel>(GetAbsoluteUrl(Routes.GetJobRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<JobResponseModel>> PostJobAsync(JobRequestModel model)
            => await mClient.PostAsync<JobResponseModel>(GetAbsoluteUrl(Routes.JobsRoute), model, null);

        public async Task<WebRequestResult<JobResponseModel>> UpdateJobAsync(int id, UpdateJobRequestModel model)
            => await mClient.PutAsync<JobResponseModel>(GetAbsoluteUrl(Routes.GetJobRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<JobResponseModel>> DeleteJobAsync(int id)
            => await mClient.DeleteAsync<JobResponseModel>(GetAbsoluteUrl(Routes.GetJobRoute(id)), null, CancellationToken.None);

        #endregion

        #region JobPosition

        public async Task<WebRequestResult<JobPositionResponseModel>> GetJobPositionAsync(int id)
            => await mClient.GetAsync<JobPositionResponseModel>(GetAbsoluteUrl(Routes.GetJobPositionRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<JobPositionResponseModel>> PostJobPositionAsync(JobPositionRequestModel model)
            => await mClient.PostAsync<JobPositionResponseModel>(GetAbsoluteUrl(Routes.JobPositionsRoute), model, null);

        public async Task<WebRequestResult<JobPositionResponseModel>> UpdateJobPositionAsync(int id, UpdateJobPositionRequestModel model)
            => await mClient.PutAsync<JobPositionResponseModel>(GetAbsoluteUrl(Routes.GetJobPositionRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<JobPositionResponseModel>> DeleteJobPositionAsync(int id)
            => await mClient.DeleteAsync<JobPositionResponseModel>(GetAbsoluteUrl(Routes.GetJobPositionRoute(id)), null, CancellationToken.None);

        #endregion

        #region JobApplication

        public async Task<WebRequestResult<JobApplicationResponseModel>> GetJobApplicationpAsync(int id)
            => await mClient.GetAsync<JobApplicationResponseModel>(GetAbsoluteUrl(Routes.GetJobApplicationRoute(id)), null, CancellationToken.None);

        public async Task<WebRequestResult<JobApplicationResponseModel>> PostJobApplicationAsync(JobApplicationRequestModel model)
            => await mClient.PostAsync<JobApplicationResponseModel>(GetAbsoluteUrl(Routes.JobApplicationsRoute), model, null);

        public async Task<WebRequestResult<JobApplicationResponseModel>> UpdateJobApplicationAsync(int id, UpdateJobApplicationRequestModel model)
            => await mClient.PutAsync<JobApplicationResponseModel>(GetAbsoluteUrl(Routes.GetJobApplicationRoute(id)), model, null, CancellationToken.None);

        public async Task<WebRequestResult<JobApplicationResponseModel>> DeleteJobApplicationAsync(int id)
            => await mClient.DeleteAsync<JobApplicationResponseModel>(GetAbsoluteUrl(Routes.GetJobApplicationRoute(id)), null, CancellationToken.None);

        #endregion

        private static string GetAbsoluteUrl(string url)
        {
            return $"https://localhost:44372/" + url;
        }

    }
}
