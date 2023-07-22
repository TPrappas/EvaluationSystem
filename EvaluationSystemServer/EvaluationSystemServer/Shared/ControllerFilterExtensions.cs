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
    }
}
