using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocialAPI.Models.Response;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Base.Middlewares
{
    public class BaseController : ControllerBase
    {
        protected ActionResult BuildResponse<TValue>(TValue value, EnResultCode code = EnResultCode.Success, string message = "", HttpStatusCode httpStatusCode = HttpStatusCode.OK, bool success = true)
        {
            int resultCount = 0;
            if (value != null && value is IList && value.GetType().IsGenericType)
            {
                var property = typeof(ICollection).GetProperty("Count");
                resultCount = (int)property.GetValue(value, null);
            }
            else if (value != null)
            {
                resultCount = 1;
            }

            if (success) code = EnResultCode.Success;
            if (!success) code = EnResultCode.Erro;

            ApiResponse<TValue> response = new()
            {
                Success = success,
                Code = code,
                Message = message,
                ResultCount = resultCount,
                Data = value
            };

            return StatusCode(httpStatusCode.GetHashCode(), response);
        }

        protected ActionResult BuildResponse(EnResultCode code = EnResultCode.Success, string message = "", HttpStatusCode httpStatusCode = HttpStatusCode.OK, bool success = true)
        {
            if (success) code = EnResultCode.Success;
            if (!success) code = EnResultCode.Erro;

            ApiResponse response = new()
            {
                Success = success,
                Code = code,
                Message = message
            };

            return StatusCode(httpStatusCode.GetHashCode(), response);
        }
    }
}