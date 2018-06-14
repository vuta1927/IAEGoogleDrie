using IAEGoogleDrie.AspNetCore.Mvc.Authorization;
using IAEGoogleDrie.AspNetCore.Mvc.ExceptionHandling;
using IAEGoogleDrie.AspNetCore.Mvc.Results;
using IAEGoogleDrie.AspNetCore.Mvc.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace IAEGoogleDrie.AspNetCore.Mvc
{
    internal static class MvcOptionsExtensions
    {
        public static void AddDomain(this MvcOptions options, IServiceCollection services)
        {
            AddFilter(options);
        }

        private static void AddFilter(MvcOptions options)
        {
            options.Filters.Add(typeof(AuthorizationFilter));
            options.Filters.Add(typeof(ValidationActionFilter));
//            options.Filters.Add(typeof(UowActionFilter));
            options.Filters.Add(typeof(ExceptionFilter));
            options.Filters.Add(typeof(AppResultFilter));
        }
    }
}