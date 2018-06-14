using System.Threading.Tasks;
using IAEGoogleDrie.AspNetCore.Mvc.Extensions;
using IAEGoogleDrie.Data.Uow;
using IAEGoogleDrie.Dependency;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Uow
{
    public class UowActionFilter : IAsyncActionFilter, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IUnitOfWorkDefaultOptions _unitOfWorkDefaultOptions;

        public UowActionFilter(IUnitOfWorkManager unitOfWorkManager, IUnitOfWorkDefaultOptions unitOfWorkDefaultOptions)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _unitOfWorkDefaultOptions = unitOfWorkDefaultOptions;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionDescriptor.IsControllerAction())
            {
                await next();
                return;
            }

            var unitOfWorkAttr = _unitOfWorkDefaultOptions
                .GetUnitOfWorkAttributeOrNull(context.ActionDescriptor.GetMethodInfo()) ?? 
                new UnitOfWorkAttribute();

            if (unitOfWorkAttr.IsDisabled)
            {
                await next();
                return;
            }

            using (var uow = _unitOfWorkManager.Begin(unitOfWorkAttr.CreateOptions()))
            {
                var result = await next();
                if (result.Exception == null || result.ExceptionHandled)
                    await uow.CompleteAsync();
            }
        }
    }
}