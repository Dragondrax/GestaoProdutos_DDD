using GestaoProdutos.Core.DomainObjects;
using System.Net;

namespace GestaoProdutos.Core.Middleware
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _next;
        public MiddlewareException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(DomainException ex)
            {
                await HandleDomainExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleDomainExceptionAsync(HttpContext context, DomainException exception)
        {
            var code = HttpStatusCode.BadRequest;

            var resultReturnError = new
            {
                Sucesso = false,
                Erros = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsJsonAsync(resultReturnError);
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var resultReturnError = new
            {
                Sucesso = false,
                Erros = "Ops, houve um problema.. tente novamente mais tarde"
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsJsonAsync(resultReturnError);
        }
    }
}
