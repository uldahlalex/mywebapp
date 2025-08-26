using mywebapp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApiDocument();
builder.Services.AddSingleton<MyFakeDatabase>();
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(app => app.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(_ => true));
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();
app.Run();
