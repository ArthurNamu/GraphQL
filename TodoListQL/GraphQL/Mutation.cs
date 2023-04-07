using TodoListQL.Data;
using TodoListQL.GraphQL.List;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }
    }
}
