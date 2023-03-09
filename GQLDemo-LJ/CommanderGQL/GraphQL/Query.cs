using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;
public class Query
{
    [UseDbContext(typeof(AppDBContext))]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDBContext context)
    {
        return context.Platforms;
    }

}
