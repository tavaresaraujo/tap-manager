using Application.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Api.Attributes
{
    public class ValidateInputAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            var errors = new Dictionary<string, IEnumerable<string>>();

            foreach (var item in context.ModelState.Where(p => p.Value.ValidationState == ModelValidationState.Invalid))
            {
                //var key = item.Key.ToSnakeCase().Replace("._", ".");
                var key = item.Key;
                var messages = item.Value.Errors.Select(p => p.Exception?.Message ?? p.ErrorMessage);
                errors.Add(key, messages);
            }

            context.HttpContext.Response.StatusCode = 400;
            context.Result = new ObjectResult(
                errors.Select(p => new UnprocessableEntityResponseModel()
                {
                    Property = p.Key,
                    Errors = p.Value.ToArray()
                })
            );
        }
    }
}
