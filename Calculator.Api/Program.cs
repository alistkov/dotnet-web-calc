using Calculator.Lib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IOperationFactory, OperationFactory>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
