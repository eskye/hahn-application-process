using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Web.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {

            switch (context.Exception)
            {
                case ApplicationException contextException:
                    context.Result =  new BadRequestObjectResult(new { contextException.Message});
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                {
                    if (context.Exception != null)
                    {
                        context.Result = new JsonResult(new { Message = "Internal server error"});
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                    break;
                }
            }
            //Automatically log every errors in the logger 
            if (context.Exception != null)
                this._logger.LogError($"ERROR:: {context.Exception.Message} \n\n - StackTrace:: {context.Exception.StackTrace}");

            base.OnException(context);
        }
    }

}
