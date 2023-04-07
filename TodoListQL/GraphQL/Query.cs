//using HotChocolate;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
      //  [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
      //  [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetData([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }

    }
}
