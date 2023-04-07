using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TodoListQL.Data;
using TodoListQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
options.UseSqlite(
   configuration.GetConnectionString("DefaultConnection")));

builder.Services
 .AddGraphQLServer()
 .AddQueryType<Query>()
 .AddType<TodoListQL.GraphQL.List.ListType>()
  .AddMutationType<Mutation>()
 .AddSorting()
  .AddProjections();

var app = builder.Build();

app.UseRouting();
//app.MapGet("/", () => "Hello World!");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(path: "/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
