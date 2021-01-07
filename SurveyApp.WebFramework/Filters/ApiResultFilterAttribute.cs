using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SurveyApp.WebFramework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.WebFramework.Filters
{
  public  class ApiResultFilterAttribute :ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult okObjectResult)
            {
                var apiResult = new ApiResult<object>(true, ApiResultStatuseCode.Success, okObjectResult.Value);
                context.Result = new JsonResult(apiResult) { StatusCode = okObjectResult.StatusCode };
            }
            else if (context.Result is OkResult okResult)
            {
                var apiResult = new ApiResult(true, ApiResultStatuseCode.Success);
                context.Result = new JsonResult(apiResult) { StatusCode = okResult.StatusCode };
            }
            //return BadRequest() method create an ObjectResult with StatusCode 400 in recent versions, So the following code has changed a bit.
            else if (context.Result is ObjectResult badRequestObjectResult && badRequestObjectResult.StatusCode == 400)
            {
                string message = null;
                switch (badRequestObjectResult.Value)
                {
                    case ValidationProblemDetails validationProblemDetails:
                        var errorMessages = validationProblemDetails.Errors.SelectMany(p => p.Value).Distinct();
                        message = string.Join(" | ", errorMessages);
                        break;
                    case SerializableError errors:
                        var errorMessages2 = errors.SelectMany(p => (string[])p.Value).Distinct();
                        message = string.Join(" | ", errorMessages2);
                        break;
                    case var value when value != null && !(value is ProblemDetails):
                        message = badRequestObjectResult.Value.ToString();
                        break;
                }

                var apiResult = new ApiResult(false, ApiResultStatuseCode.BadRequest, message);
                context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
            }
            else if (context.Result is ObjectResult notFoundObjectResult && notFoundObjectResult.StatusCode == 404)
            {
                string message = null;
                if (notFoundObjectResult.Value != null && !(notFoundObjectResult.Value is ProblemDetails))
                    message = notFoundObjectResult.Value.ToString();

                //var apiResult = new ApiResult<object>(false, ApiResultStatuseCode.NotFound, notFoundObjectResult.Value);
                var apiResult = new ApiResult(false, ApiResultStatuseCode.NotFound, message);
                context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
            }
            else if (context.Result is ContentResult contentResult)
            {
                var apiResult = new ApiResult(true, ApiResultStatuseCode.Success, contentResult.Content);
                context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
            }
            else if (context.Result is ObjectResult objectResult && objectResult.StatusCode == null
                && !(objectResult.Value is ApiResult))
            {
                var apiResult = new ApiResult<object>(true, ApiResultStatuseCode.Success, objectResult.Value);
                context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
            }

            base.OnResultExecuting(context);
        }
    }
}