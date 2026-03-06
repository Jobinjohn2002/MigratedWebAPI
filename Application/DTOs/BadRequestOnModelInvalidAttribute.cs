using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BadRequestOnModelInvalidAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(new
                {
                    Message = "Invalid request body",
                    Errors = errors
                });
            }

            base.OnActionExecuting(context);
        }
    }
}