using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Filters
{
    public class ValidatorActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                context.Result = new BadRequestObjectResult(errors);
            }
            base.OnActionExecuting(context);
        }
    }
}
