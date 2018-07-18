using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Ajax.Utilities;
using Wasenshi.CreditCard.WebAPI.Common;

namespace Wasenshi.CreditCard.WebAPI
{
    public static class FilterConfig
    {
        public static void Register(HttpFilterCollection filters)
        {
            // Error Handler
            filters.Add(new ErrorHandlerFilterAttribute());
            // Log Handler
            filters.Add(new LogFilterAttribute());
        }
    }

    public class ErrorHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public static readonly IReadOnlyDictionary<Type, HttpStatusCode> EXCEPTION_HTTP_STATUS_CODE_MAPPER = new Dictionary<Type, HttpStatusCode>
        {
            {typeof (ArgumentException), HttpStatusCode.BadRequest},
            {typeof (UnauthorizedAccessException), HttpStatusCode.Unauthorized},
            {typeof (InvalidCredentialException), HttpStatusCode.Forbidden},
            {typeof (InvalidOperationException), HttpStatusCode.BadRequest},
            {typeof (ObjectNotFoundException), HttpStatusCode.NotFound}
        };

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage message;
            // Logs error.
            WindsorConfig.Container.Resolve<ILogger>().LogError(actionExecutedContext.Exception);


            HttpStatusCode statusCode = GetHttpStatusCode(actionExecutedContext.Exception);

            if (actionExecutedContext.Exception.InnerException != null)
            {
                message = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(actionExecutedContext.Exception.InnerException.Message)
                };
            }
            else
            {
                message = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(actionExecutedContext.Exception.Message)
                };
            }

            actionExecutedContext.Response = message;
            actionExecutedContext.Response.RequestMessage = actionExecutedContext.Request;
        }

        private HttpStatusCode GetHttpStatusCode(Exception ex)
        {
            var result = HttpStatusCode.InternalServerError;
            EXCEPTION_HTTP_STATUS_CODE_MAPPER.FirstOrDefault(pair => pair.Key.IsInstanceOfType(ex))
                .IfNotNull(pair => result = pair.Value);
            
            return result;
        }
    }

    public class LogFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Logs before running action.
            WindsorConfig.Container.Resolve<ILogger>().LogDebug(
                $"The action [{actionContext.ActionDescriptor.ActionName}] of controller [{actionContext.ActionDescriptor.ControllerDescriptor.ControllerName}] has been called.");
        }

        /// <summary>
        /// Occurs after the action method is invoked.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Logs after finished action.
            WindsorConfig.Container.Resolve<ILogger>().LogDebug(
                $"The action [{actionExecutedContext.ActionContext.ActionDescriptor.ActionName}] of controller [{actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName}] has completed.");
        }
    }
}
