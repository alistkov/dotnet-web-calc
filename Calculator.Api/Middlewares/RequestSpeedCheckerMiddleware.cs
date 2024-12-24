using Timer = System.Timers.Timer;

namespace Calculator.Api.Middlewares;

public class RequestSpeedCheckerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var timer = new Timer();
        
        timer.Start();
        
        await next(context);
        
        timer.Stop();
        Console.WriteLine($"{timer.Interval / 1000}s");
    }
}