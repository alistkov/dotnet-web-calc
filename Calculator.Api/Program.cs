using Calculator.Api.Middlewares;
using System.Reflection;
using Calculator.Lib;
using Calculator.Lib.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(configuration =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    
    configuration.IncludeXmlComments(xmlCommentsFullPath);
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IOperationFactory, OperationDecorator>();
builder.Services.AddScoped<OperationMiddleware>();
builder.Services.AddScoped<IncreaseMiddleware>();
builder.Services.AddScoped<RequestSpeedCheckerMiddleware>();

var app = builder.Build();

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

app.Run();
