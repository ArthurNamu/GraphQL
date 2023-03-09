using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;
public class Query
{
    public IQueryable<Platform> GetPlatform([Service] AppDBContext context)
    {
        return context.Platforms;
    }

}
