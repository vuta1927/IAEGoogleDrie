using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Results.Wrapping
{
    public interface IActionResultWrapper
    {
        void Wrap(ResultExecutingContext actionResult);
    }
}