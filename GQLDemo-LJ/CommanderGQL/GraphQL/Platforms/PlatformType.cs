using CommanderGQL.Data;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore.Design;
using System.Runtime.CompilerServices;

namespace CommanderGQL.GraphQL.Platforms;
public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or service that has a commandline interface.");

        descriptor
            .Field(p => p.LicenseKey).Ignore();

        //descriptor
        //    .Field(p => p.Commands)
        //    .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
        //    .UseDbContext<AppDBContext>()
        //    .Description("This is the list of available commands for this platform");
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDBContext context)
        {
            return context.Commands.Where(p => p.PlatformId == platform.Id);

            
        }
    }
}
