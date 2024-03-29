﻿using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;
public class Query
{
    [UseDbContext(typeof(AppDBContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]

    public IQueryable<Platform> GetPlatform([ScopedService] AppDBContext context)
    {
        return context.Platforms;
    }
    [UseDbContext(typeof(AppDBContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommand([ScopedService] AppDBContext context)
    {
        return context.Commands;
    }

}
