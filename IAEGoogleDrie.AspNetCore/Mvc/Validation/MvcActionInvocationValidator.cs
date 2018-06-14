using System;
using IAEGoogleDrie.AspNetCore.Mvc.Extensions;
using IAEGoogleDrie.Helpers.Extensions;
using IAEGoogleDrie.Validation.Interception;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Validation
{
    public class MvcActionInvocationValidator : MethodInvocationValidator
    {
        protected ActionExecutingContext ActionContext { get; private set; }

        public MvcActionInvocationValidator(IServiceProvider iocResolver)
            : base(iocResolver)
        {
        }

        public void Initialize(ActionExecutingContext actionContext)
        {
            ActionContext = actionContext;
            
            base.Initialize(
                actionContext.ActionDescriptor.GetMethodInfo(),
                GetParameterValues(actionContext)
            );
        }
        
        protected virtual object[] GetParameterValues(ActionExecutingContext actionContext)
        {
            var methodInfo = actionContext.ActionDescriptor.GetMethodInfo();

            var parameters = methodInfo.GetParameters();
            var parameterValues = new object[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                parameterValues[i] = actionContext.ActionArguments.GetOrDefault(parameters[i].Name);
            }

            return parameterValues;
        }
    }
}