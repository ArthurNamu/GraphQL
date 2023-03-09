var builder = WebApplication.CreateBuilder(args);

//builder.Services
IConfiguration configuration = builder.Configuration;


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
