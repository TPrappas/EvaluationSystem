// Ignore Spelling: Admin

using EvaluationSystemServer.Arguments.Jobs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public static class ControllerFilterExtensions
    {
        public static List<Expression<Func<CertificateEntity, bool>>> AddCertificateFilters(this List<Expression<Func<CertificateEntity, bool>>> filters, CertificateArgs? args)
        {
            if (args is null)
                return filters;

            //// If Search is not null...
            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)) || x.Department.Contains(args.Search));

            if (!args.IncludeDepartments.IsNullOrEmpty())
                filters.Add(x => args.IncludeDepartments.Contains(x.Department));

            if (!args.ExcludeDepartments.IsNullOrEmpty())
                filters.Add(x => !args.ExcludeDepartments.Contains(x.Department));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the After Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            return filters;
        }

        public static List<Expression<Func<SkillEntity, bool>>> AddSkillFilters(this List<Expression<Func<SkillEntity, bool>>> filters, SkillArgs? args)
        {
            if (args is null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            return filters;

        }

        public static List<Expression<Func<MeetingEntity, bool>>> AddMeetingFilters(this List<Expression<Func<MeetingEntity, bool>>> filters, MeetingArgs? args)
        {
            if (args is null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the included Organizers is not null...
            if (args.IncludeOrganizer is not null)
                // Add to filters
                filters.Add(x => args.IncludeOrganizer.Contains(x.OrganizerId));

            // If the excluded Organizers is not null...
            if (args.ExcludeOrganizer is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeOrganizer.Contains(x.OrganizerId));

            // If the After Date is not null...
            if (args.AfterDate is not null)
                // Add to filters
                filters.Add(x => x.MeetingDate >= args.AfterDate);

            // If the Before Date is not null...
            if (args.BeforeDate is not null)
                // Add to filters
                filters.Add(x => x.MeetingDate <= args.BeforeDate);

            // If the min Duration is not null...
            if (args.MinDuration is not null)
                // Add to filters
                filters.Add(x => args.MinDuration >= x.Duration);

            // If the max Duration is not null...
            if (args.MaxDuration is not null)
                // Add to filters
                filters.Add(x => args.MaxDuration <= x.Duration);

            return filters;

        }

        public static List<Expression<Func<ProjectEntity, bool>>> AddProjectFilters(this List<Expression<Func<ProjectEntity, bool>>> filters, ProjectArgs? args)
        {
            if (args == null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the After Submission Start is not null...
            if (args.AfterSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart >= args.AfterSubmissionStart);

            // If the Before Submission Start is not null...
            if (args.BeforeSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart <= args.BeforeSubmissionStart);

            // If the After Submission End is not null...
            if (args.AfterSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd >= args.AfterSubmissionEnd);

            // If the Before Submission End is not null...
            if (args.BeforeSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd <= args.BeforeSubmissionEnd);

            // If the included Users is not null...
            if (args.IncludeUsers is not null)
                // Add to filters
                filters.Add(x => args.IncludeUsers.Contains(x.UserId));

            // If the excluded Users is not null...
            if (args.ExcludeUsers is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeUsers.Contains(x.UserId));

            return filters;

        }

        public static List<Expression<Func<CategoryEntity, bool>>> AddCategoryFilters(this List<Expression<Func<CategoryEntity, bool>>> filters, CategoryArgs? args)
        {
            if (args == null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            return filters;
        }

        public static List<Expression<Func<JobApplicationEntity, bool>>> AddJobApplicationFilters(this List<Expression<Func<JobApplicationEntity, bool>>> filters, JobApplicationArgs? args)
        {
            if (args == null)
                return filters;

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the Min Grade is not null...
            if (args.MinGrade is not null)
                // Add to filters
                filters.Add(x => args.MinGrade >= x.Grade);

            // If the Min Grade is not null...
            if (args.MaxGrade is not null)
                // Add to filters
                filters.Add(x => args.MaxGrade <= x.Grade);

            // If the After Submission Start is not null...
            if (args.AfterSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart >= args.AfterSubmissionStart);

            // If the Before Submission Start is not null...
            if (args.BeforeSubmissionStart is not null)
                // Add to filters
                filters.Add(x => x.SubmissionStart <= args.BeforeSubmissionStart);

            // If the After Submission End is not null...
            if (args.AfterSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd >= args.AfterSubmissionEnd);

            // If the Before Submission End is not null...
            if (args.BeforeSubmissionEnd is not null)
                // Add to filters
                filters.Add(x => x.SubmissionEnd <= args.BeforeSubmissionEnd);

            // If the included Employees is not null...
            if (args.IncludeEmployees is not null)
                // Add to filters
                filters.Add(x => args.IncludeEmployees.Contains(x.EmployeeId));

            // If the excluded Employees is not null...
            if (args.ExcludeEmployees is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeEmployees.Contains(x.EmployeeId));

            // If the included Evaluator is not null...
            if (args.IncludeEvaluators is not null)
                // Add to filters
                filters.Add(x => args.IncludeEvaluators.Contains(x.EvaluatorId));

            // If the excluded Evaluator is not null...
            if (args.ExcludeEvaluators is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeEvaluators.Contains(x.EvaluatorId));

            // If the included Manager is not null...
            if (args.IncludeManagers is not null)
                // Add to filters
                filters.Add(x => args.IncludeManagers.Contains(x.ManagerId));

            // If the excluded Manager is not null...
            if (args.ExcludeManagers is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeManagers.Contains(x.ManagerId));

            return filters;
        }

        public static List<Expression<Func<JobEntity, bool>>> AddJobFilters(this List<Expression<Func<JobEntity, bool>>> filters, JobArgs? args)
        {
            if (args == null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the min Salary is not null...
            if (args.MinSalary is not null)
                // Add to filters
                filters.Add(x => args.MinSalary >= x.Salary);

            // If the max Salary is not null...
            if (args.MaxSalary is not null)
                // Add to filters
                filters.Add(x => args.MaxSalary <= x.Salary);

            return filters;
        }

        public static List<Expression<Func<JobPositionEntity, bool>>> AddJobPositionFilters(this List<Expression<Func<JobPositionEntity, bool>>> filters, JobPositionArgs? args)
        {
            if (args == null)
                return filters;

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the is Open is not null...
            if (args.isOpen is not null)
                // Add to filters
                filters.Add(x => args.isOpen == x.IsOpen);

            // If the included Jobs is not null...
            if (args.IncludeJobs is not null)
                // Add to filters
                filters.Add(x => args.IncludeJobs.Contains(x.JobId));

            // If the excluded Jobs is not null...
            if (args.ExcludeJobs is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeJobs.Contains(x.JobId));

            // If the included Companies is not null...
            if (args.IncludeCompanies is not null)
                // Add to filters
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            // If the excluded Companies is not null...
            if (args.ExcludeCompanies is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            return filters;
        }

        public static List<Expression<Func<AdminEntity, bool>>> AddAdminFilters(this List<Expression<Func<AdminEntity, bool>>> filters, AdminArgs? args)
        {
            if (args == null)
                return filters;

            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            return filters;
        }

        public static List<Expression<Func<CompanyEntity, bool>>> AddCompanyFilters(this List<Expression<Func<CompanyEntity, bool>>> filters, CompanyArgs? args)
        {
            if (args == null)
                return filters;

            //// If Search is not null...
            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)) || x.Country.Contains(args.Search) || x.DOY.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            return filters;
        }

        public static List<Expression<Func<UserEntity, bool>>> AddUserFilters(this List<Expression<Func<UserEntity, bool>>> filters, UserArgs? args)
        {
            if (args == null)
                return filters;

            // If Search is not null...
            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)) || x.FirstName.Contains(args.Search) || x.LastName.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the Min Rating is not null...
            if (args.MinRating is not null)
                // Add to filters
                filters.Add(x => args.MinRating >= x.Rating);

            // If the Max Rating is not null...
            if (args.MaxRating is not null)
                // Add to filters
                filters.Add(x => args.MaxRating <= x.Rating);

            // If the UserType is not null...
            if (args.UserType is not null)
                // Add to filters
                filters.Add(x => args.UserType == x.UserType);

            // If the included Companies is not null...
            if (args.IncludeCompanies is not null)
                // Add to filters
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            // If the excluded Companies is not null...
            if (args.ExcludeCompanies is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            // If the included Job Positions is not null...
            if (args.IncludeJobPositions is not null)
                // Add to filters
                filters.Add(x => args.IncludeJobPositions.Contains(x.JobPositionId));

            // If the excluded Job Positions is not null...
            if (args.ExcludeJobPositions is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeJobPositions.Contains(x.JobPositionId));

            return filters;
        }

        public static List<Expression<Func<LicenseEntity, bool>>> AddLicenseFilters(this List<Expression<Func<LicenseEntity, bool>>> filters, LicenseArgs? args)
        {
            if (args == null)
                return filters;

            // If Search is not null...
            //if (!string.IsNullOrEmpty(args.Search))
            //    // Add to filters
            //    filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the After Activation Date is not null...
            if (args.AfterActivationDate is not null)
                // Add to filters
                filters.Add(x => x.ActivationDate >= args.AfterActivationDate);

            // If the Before Activation Created is not null...
            if (args.BeforeActivationDate is not null)
                // Add to filters
                filters.Add(x => x.ActivationDate <= args.BeforeActivationDate);

            // If the After Expiration Date is not null...
            if (args.AfterExpirationDate is not null)
                // Add to filters
                filters.Add(x => x.ExpirationDate >= args.AfterExpirationDate);

            // If the Before Expiration Created is not null...
            if (args.BeforeExpirationDate is not null)
                // Add to filters
                filters.Add(x => x.ExpirationDate <= args.BeforeExpirationDate);

            // If the included Licenses is not null...
            if (args.IncludeCompanies is not null)
                // Add to filters
                filters.Add(x => args.IncludeCompanies.Contains(x.CompanyId));

            // If the excluded Licenses is not null...
            if (args.ExcludeCompanies is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeCompanies.Contains(x.CompanyId));

            return filters;
        }

        public static List<Expression<Func<NotificationEntity, bool>>> AddNotificationFilters(this List<Expression<Func<NotificationEntity, bool>>> filters, NotificationArgs? args)
        {
            if (args == null)
                return filters;

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the NotificationType is not null...
            if (args.NotificationType is not null)
                // Add to filters
                filters.Add(x => args.NotificationType == x.NotificationType);

            // If the included Users is not null...
            if (args.IncludeUsers is not null)
                // Add to filters
                filters.Add(x => args.IncludeUsers.Contains(x.UserId));

            // If the excluded Users is not null...
            if (args.ExcludeUsers is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeUsers.Contains(x.UserId));

            return filters;
        }
    }
}
