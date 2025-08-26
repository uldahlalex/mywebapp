using mywebapp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApiDocument();
builder.Services.AddSingleton<MyFakeDatabase>();
builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();
app.Run();
