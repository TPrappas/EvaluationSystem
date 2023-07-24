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

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)) || x.Department.Contains(args.Search));

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

            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

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

            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.NormalizedName.Contains(ControllerHelpers.NormalizeString(args.Search)));

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
    }
}
