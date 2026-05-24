namespace TicketManagmentSystem.Server.Middlewares
{
    public class GlobalErrorHandler
    {
        public readonly RequestDelegate _next;
        public GlobalErrorHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }

    }
}
