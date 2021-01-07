using Microsoft.AspNetCore.Mvc;
using SurveyApp.Infrastucture.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.WebFramework.Api
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatuseCode StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatuseCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, ApiResultStatuseCode.Success);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, ApiResultStatuseCode.BadRequest);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult(false, ApiResultStatuseCode.BadRequest, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, ApiResultStatuseCode.Success, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, ApiResultStatuseCode.NotFound);
        }
        #endregion
    }

    public class ApiResult<TData> : ApiResult
        where TData:class
    {

        public TData Data { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatuseCode statusCode,TData data,string message=null)
            :base(isSuccess,statusCode,message)
        {
            Data = data;
        }

        #region Implicit Operators  
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, ApiResultStatuseCode.Success, data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatuseCode.Success, null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatuseCode.Success, (TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatuseCode.BadRequest, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult<TData>(false, ApiResultStatuseCode.BadRequest, null, message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatuseCode.Success, null, result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatuseCode.NotFound, null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatuseCode.NotFound, (TData)result.Value);
        }
        #endregion
    }
}
