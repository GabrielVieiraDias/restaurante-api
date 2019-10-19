using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Restaurante.Service.Exceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : GetErrorCode(context.Exception.GetType());

            string errorMessage = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = new ObjectResult(new
            {
                StatusCode = (int)statusCode,
                Message = errorMessage,
                StackTrace = stackTrace,
                IsError = true
            });

            context.Result = result;
        }

        private HttpStatusCode GetErrorCode(Type exceptionType)
        {
            if (Enum.TryParse<Restaurante.Domain.Enums.Exceptions>(exceptionType.Name, out Domain.Enums.Exceptions tryParseResult))
            {
                switch (tryParseResult)
                {
                    case Restaurante.Domain.Enums.Exceptions.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case Restaurante.Domain.Enums.Exceptions.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case Restaurante.Domain.Enums.Exceptions.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Restaurante.Domain.Enums.Exceptions.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case Restaurante.Domain.Enums.Exceptions.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case Restaurante.Domain.Enums.Exceptions.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case Restaurante.Domain.Enums.Exceptions.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case Restaurante.Domain.Enums.Exceptions.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case Restaurante.Domain.Enums.Exceptions.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case Restaurante.Domain.Enums.Exceptions.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case Restaurante.Domain.Enums.Exceptions.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case Restaurante.Domain.Enums.Exceptions.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case Restaurante.Domain.Enums.Exceptions.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Restaurante.Domain.Enums.Exceptions.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case Restaurante.Domain.Enums.Exceptions.IOException:
                        return HttpStatusCode.NotFound;

                    case Restaurante.Domain.Enums.Exceptions.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    case Restaurante.Domain.Enums.Exceptions.AppException:
                        return HttpStatusCode.InternalServerError;

                    case Restaurante.Domain.Enums.Exceptions.ArgumentNullException:
                        return HttpStatusCode.NotFound;

                    case Restaurante.Domain.Enums.Exceptions.ForbiddenException:
                        return HttpStatusCode.Forbidden;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}