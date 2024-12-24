using System.Reflection;
using Calculator.Api.Middlewares;

namespace Calculator.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        
        builder.Services.AddScoped<OperationMiddleware>();
        builder.Services.AddScoped<IncreaseMiddleware>();
        builder.Services.AddScoped<RequestSpeedCheckerMiddleware>();
        
        builder.Services.AddSwaggerGen(configuration =>
        {
            var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
     
            configuration.IncludeXmlComments(xmlCommentsFullPath);
        });
        
        return builder.Build();
    }

    public static WebApplication ConfigurePipeLine(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseMiddleware<IncreaseMiddleware>();
        app.UseMiddleware<OperationMiddleware>();
        app.UseMiddleware<RequestSpeedCheckerMiddleware>();
        app.MapControllers();
        return app;
    }
}