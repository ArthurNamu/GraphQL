using CommanderGQL.Data;
using CommanderGQL.GraphQL;
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
    .AddQueryType<Query>();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(path: "/graphql-voyager",  new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});


app.Run();
