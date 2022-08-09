using System.Net;
using System.Text.Json;
using YulinTestOrg.Extensions;
using YulinTestOrg.Utility.Response;

namespace YulinTestOrg.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var model = new ResponseBaseModel<string>
            {
                ErrCode = ResponseErrCode.SYSTEM,
                MsgCode = "EX00000",
                ErrMsg = ""
            };

            if (exception is ValidateException)
            {
                code = HttpStatusCode.BadRequest;

                ValidateException ex = exception as ValidateException;

                model.ErrCode = ResponseErrCode.VALIDATE;
                model.MsgCode = ex.MsgCode;
                model.ErrMsg = ex.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(JsonSerializer.Serialize(model));
        }

        public class ExceptionResponseModel
        {
            public int Status { get; set; }
            public string Error { get; set; }
        }
    }
}
