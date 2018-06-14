using IAEGoogleDrie.AspNetCore.Mvc.Extensions;
using IAEGoogleDrie.AspNetCore.Mvc.Results.Wrapping;
using IAEGoogleDrie.Dependency;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Results
{
    public class AppResultFilter : IResultFilter, ITransientDependency
    {
        private readonly IActionResultWrapperFactory _actionResultWrapperFactory;

        public AppResultFilter(IActionResultWrapperFactory actionResultWrapper)
        {
            _actionResultWrapperFactory = actionResultWrapper;
        }

        public virtual void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ActionDescriptor.IsControllerAction())
            {
                return;
            }
            
            _actionResultWrapperFactory.CreateFor(context).Wrap(context);
        }

        public virtual void OnResultExecuted(ResultExecutedContext context)
        {
            //no action
        }
    }
}