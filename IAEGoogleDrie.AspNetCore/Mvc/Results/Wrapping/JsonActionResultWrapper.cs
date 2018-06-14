using System;
using IAEGoogleDrie.AspNetCore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IAEGoogleDrie.AspNetCore.Mvc.Results.Wrapping
{
    public class JsonActionResultWrapper : IActionResultWrapper
    {
        public void Wrap(ResultExecutingContext actionResult)
        {
            var jsonResult = actionResult.Result as JsonResult;
            if (jsonResult == null)
            {
                throw new ArgumentException($"{nameof(actionResult)} should be JsonResult!");
            }

            if (!(jsonResult.Value is AjaxResponseBase))
            {
                jsonResult.Value = new AjaxResponse(jsonResult.Value);
            }
        }
    }
}