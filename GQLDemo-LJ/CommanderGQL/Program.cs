using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services
IConfiguration configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<AppDBContext>(opt => opt
.UseSqlServer(configuration.GetConnectionString("CommandConnStr")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddMutationType<Mutation>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(path: "/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});


app.Run();
