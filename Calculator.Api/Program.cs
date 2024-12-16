using System.Reflection;
using Calculator.Api.Middleware;
using Calculator.Lib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(configuration =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    
    configuration.IncludeXmlComments(xmlCommentsFullPath);
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IOperationFactory, OperationFactory>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseOperationImplement();
app.MapControllers();

app.Run();
