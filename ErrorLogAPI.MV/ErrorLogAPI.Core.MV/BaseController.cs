using ErrorLogAPI.Library.MV;
using Extensions.MV;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ErrorLogAPI.Core.MV
{
    public class BaseController : ApiController
    {
        protected IErrorLogger _errorLogger;

        protected string _baseErrorMessage;

        public BaseController(IErrorLogger errorLogger, string baseErrorMessage)
        {
            _errorLogger = errorLogger;
            _baseErrorMessage = baseErrorMessage;
        }

        protected HttpResponseMessage ExecFunc(Func<HttpResponseMessage> function, string errorMessage = null)
        {
            try
            {
                return function();
            }
            catch (DomainException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex);
                if (errorMessage.IsNullOrEmpty()) errorMessage = _baseErrorMessage;
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessage);
            }
        }
    }
}
