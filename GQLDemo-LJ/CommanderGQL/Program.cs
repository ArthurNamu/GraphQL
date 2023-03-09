using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<AppDBContext>(opt => opt
.UseSqlServer(configuration.GetConnectionString("CommandConnStr")));



var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
