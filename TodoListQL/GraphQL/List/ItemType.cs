using System.Runtime.CompilerServices;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL.List
{
    public class ItemType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("This model is used as item for the list");

            descriptor.Field(x => x.ItemDatas)
                .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the list that the item belongs to.");
        }



        private class Resolvers
        {
            public IQueryable<ItemData> GetItems([Parent] ItemList list, [ScopedService] ApiDbContext context)
            {
                return context.Items.Where(x => x.ListId == list.Id);
            }
        }
    }
}
