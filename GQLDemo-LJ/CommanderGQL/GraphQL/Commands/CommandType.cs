using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;
using System;

namespace CommanderGQL.GraphQL.Commands;
public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command");

        //descriptor
        //          .Field(c => c.Platform)
        //          .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
        //          .UseDbContext<AppDBContext>()
        //          .Description("This is the platform to which the command belongs.");

    }

    private class Resolvers
    {
        public Platform GetPlatform(Command command, [ScopedService] AppDBContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        }
    }
}


