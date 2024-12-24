namespace Calculator.Api.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseOperationImplement(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<OperationImplementMiddleware>();
    }
}