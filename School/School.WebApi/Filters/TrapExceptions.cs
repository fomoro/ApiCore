using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using School.BussinessLogic.Exceptions;

namespace School.WebApi.Filters
{
    public class TrapExceptions : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500;
            string content = context.Exception.Message;

            var type = context.Exception.GetType();
            if (type == typeof(DuplicatedObjectException))
            {
                statusCode = 522; //Conflict
            } 
            else if (type == typeof(ArgumentNullException))
            {
                statusCode = 400; //Bad Request
            }
            else
            {
                content = "Internal Server Error";
            }

            context.Result = new ContentResult()
            {
                StatusCode = statusCode,
                Content = content
            };
        }
    }

}
