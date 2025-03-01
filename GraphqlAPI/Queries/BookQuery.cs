using BusinessLayer.Interfaces;
using GraphQL;
using GraphQL.Types;
using GraphqlAPI.Types;

namespace GraphqlAPI.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookService bookService)
        {
            Field<ListGraphType<BookType>>("Books").Resolve(context => bookService.GetAll());

            Field<BookType>("BookById")
                .Arguments(new QueryArgument<IntGraphType> { Name = "id", Description = "id is required" })
                .Resolve(context => bookService.Get(context.GetArgument<int>("id")));
        }
    }
}
