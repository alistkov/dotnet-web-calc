using Calculator.Application.Base;
using Calculator.Application.Interfaces;

namespace Calculator.Api.Middlewares;

public class OperationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var randomNumber = new Random().Next(1, 100);
        if (context.RequestServices.GetService(typeof(IOperationFactory)) is OperationDecorator factory)
        {
            if (randomNumber % 2 == 0)
                factory.Factory = new ReverseOperationFactory();
            else
                factory.Factory = new OperationFactory();
        }
        
        await next(context);
    }
}