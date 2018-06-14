using IAEGoogleDrie.AspNetCore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Results.Wrapping
{
    public class EmptyActionResultWrapper : IActionResultWrapper
    {
        public void Wrap(ResultExecutingContext actionResult)
        {
            actionResult.Result = new ObjectResult(new AjaxResponse());
        }
    }
}