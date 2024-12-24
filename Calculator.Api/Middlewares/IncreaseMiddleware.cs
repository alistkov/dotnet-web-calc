namespace Calculator.Api.Middlewares;

public class IncreaseMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var query = context.Request.Query.ToDictionary();
        if (query.Any())
        {
            var first = double.Parse(query["first"]);
            var second = double.Parse(query["second"]);

            query["first"] = $"{first * 2}";
            query["second"] = $"{second * 2}";

            context.Request.Query = new QueryCollection(query);
        }
        await next(context);
    }
}