using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//builder.Services
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<AppDBContext>(opt => opt
.UseSqlServer(configuration.GetConnectionString("CommandConnStr")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
