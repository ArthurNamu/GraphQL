using CommanderGQL.Data;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;
public class Mutation
{
    [UseDbContext(typeof(AppDBContext))]
    public async Task<AddPlatformPaylod> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDBContext context)
    {
        var platform = new Platform { Name = input.Name, LicenseKey = input.LicenseKey };

        context.Platforms.Add(platform);
        await context.SaveChangesAsync();

        return new AddPlatformPaylod(platform);
    }
}
