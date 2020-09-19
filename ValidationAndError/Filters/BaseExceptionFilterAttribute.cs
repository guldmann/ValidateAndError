using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using ValidationAndError.Models;

namespace ValidationAndError.Filters
{
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is FluentValidation.ValidationException validationException)
            {
                var envelope = new Envelope(validationException.Errors.Select(e => new Error
                {
                    Code = Convert.ToString(e.ErrorCode),
                    Parameter = e.PropertyName,
                    Value = Convert.ToString(e.AttemptedValue),
                    Details = null,
                    Message = e.ErrorMessage
                }).ToList()
                )
                {
                    Path = context.HttpContext.Request.Path,
                    Status = 400,
                    Request = context.HttpContext.Request.GetEncodedUrl(),
                    TraceId = context.HttpContext.TraceIdentifier
                };
                context.HttpContext.Response.StatusCode = 400;
                context.HttpContext.Response.ContentType = "application/json";

                context.Result = new JsonResult(envelope);

                base.OnException(context);
            }

            //TODO  Handle other types of exception here
        }
    }
}