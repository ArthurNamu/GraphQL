using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;
public class Query
{
    [UseDbContext(typeof(AppDBContext))]
    [UseProjection]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDBContext context)
    {
        return context.Platforms;
    }

}
