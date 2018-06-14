using IAEGoogleDrie.Dependency;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Results.Wrapping
{
    public interface IActionResultWrapperFactory : ITransientDependency
    {
        IActionResultWrapper CreateFor([NotNull] ResultExecutingContext actionResult);
    }
}