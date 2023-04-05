using Microsoft.EntityFrameworkCore;
using TodoListQL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
