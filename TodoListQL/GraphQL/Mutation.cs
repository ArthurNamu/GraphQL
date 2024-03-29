﻿using TodoListQL.Data;
using TodoListQL.GraphQL.DataItem;
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

        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var item = new ItemData
            {
                IsDone = input.isDone,
                Description = input.description,
                Title = input.title,
                ListId = input.listId
            };

            context.Add(item);

            context.SaveChanges();

            return new AddItemPayload(item);
        }
    }
}
