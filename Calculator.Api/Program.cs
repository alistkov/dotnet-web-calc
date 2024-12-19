using Calculator.Api.Middlewares;
using Calculator.Lib;
using Calculator.Lib.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IOperationFactory, OperationDecorator>();
builder.Services.AddScoped<OperationMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<OperationMiddleware>();
app.MapControllers();

app.Run();
