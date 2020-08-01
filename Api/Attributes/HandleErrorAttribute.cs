using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Application.Models.Exceptions;
using Application.Helpers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Api.Attributes
{
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {

        //readonly string _application;
        //readonly string _service;
        //readonly IHostingEnvironment _environment;

        //public HandleErrorAttribute(IConfigurationRoot configuration, IHostingEnvironment environment)
        //{
        //    _environment = environment;
        //    _application = configuration.GetValue<string>("AppSettings:Application");
        //    _service = configuration.GetValue<string>("AppSettings:Service");
        //}

        public override void OnException(ExceptionContext context)
        {
            int status;
            object value;
            //SeverityLevel level;

            if (context.Exception is NotFoundException)
            {
                var ex = context.Exception as NotFoundException;
                status = (int)HttpStatusCode.NotFound;
                //level = SeverityLevel.Warning;
                value = new NotFoundResponseModel()
                {
                    Object = ex.Entity,
                    Message = ex.Message
                };
            }
            else if (context.Exception is PreconditionFailedException)
            {
                var ex = context.Exception as PreconditionFailedException;
                status = (int)HttpStatusCode.PreconditionFailed;
                //level = SeverityLevel.Warning;
                value = new PreconditionFailedResponseModel()
                {
                    Code = ex.Code,
                    Message = ex.Message
                };
            }
            else if (context.Exception is UnprocessableEntityException)
            {
                var ex = context.Exception as UnprocessableEntityException;
                status = (int)HttpStatusCode.UnprocessableEntity;
                //level = SeverityLevel.Warning;
                value = ex.Errors.Select(p => new UnprocessableEntityResponseModel()
                {
                    Property = p.Key,
                    Errors = p.Value.ToArray()
                });
            }
            else
            {
                status = (int)HttpStatusCode.InternalServerError;
                //level = SeverityLevel.Error;
                value = new InternalServerErrorResponseModel()
                {
                    Message = "Internal server error."
                };
            }

            var action = context.ActionDescriptor as ControllerActionDescriptor;

            context.Result = new ObjectResult(value) { StatusCode = status };
            context.HttpContext.Response.StatusCode = status;
            bool internalServerError = status == 500 ? true : false;

            //Logger.Write(new HttpResponseLog()
            //{
            //    Application = _application,
            //    ServiceName = _service,
            //    Content = internalServerError ? context.Exception : value,
            //    Action = action.ActionName,
            //    Controller = action.ControllerName,
            //    Method = context.HttpContext.Request.Method,
            //    Environment = _environment.EnvironmentName,
            //    StatusCode = status,
            //    TimeElapsed = ApplicationContext.Get<Stopwatch>("Stopwatch")?.Elapsed ?? TimeSpan.Zero,
            //    SeverityLevel = level,
            //    Exception = context.Exception,
            //    RequestId = ApplicationContext.Get<string>("RequestId")
            //});


        }
    }

}
