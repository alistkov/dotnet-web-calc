namespace Calculator.Api.Middleware;

public class OperationImplementMiddleware
{
    private readonly RequestDelegate _next;

    public OperationImplementMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var random = new Random().Next(0, 10);

        Console.WriteLine(random);
        await _next(context);
    }
}