using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TodoListQL.Data;
using TodoListQL.GraphQL;
using TodoListQL.GraphQL.List;
var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
options.UseSqlite(
   configuration.GetConnectionString("DefaultConnection")));

builder.Services
 .AddGraphQLServer()
 .AddQueryType<Query>()
 .AddType<ItemType>()
  .AddMutationType<Mutation>()
 .AddSorting()
.AddFiltering()
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
