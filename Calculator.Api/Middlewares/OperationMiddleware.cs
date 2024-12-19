using Calculator.Lib;
using Calculator.Lib.Interfaces;

namespace Calculator.Api.Middlewares;

public class OperationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var randomNumber = new Random().Next(1, 100);
        OperationDecorator factory = (OperationDecorator) context.RequestServices.GetService(typeof(IOperationFactory))!;

        if (randomNumber % 2 == 0)
            factory.Factory = new ReverseOperationFactory();
        else
            factory.Factory = new OperationFactory();
        
        await next(context);
    }
}