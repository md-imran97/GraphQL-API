using BusinessLayer.Interfaces;
using GraphQL;
using GraphQL.Types;
using GraphqlAPI.Types;

namespace GraphqlAPI.Queries
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(IAuthorService authorService)
        {
            Field<ListGraphType<AuthorType>>("Authors").Resolve(context => authorService.GetAll());

            Field<AuthorType>("AuthorById")
                .Arguments(new QueryArgument<IntGraphType> { Name = "id", Description = "id is required" })
                .Resolve(context => authorService.Get(context.GetArgument<int>("id")));
        }
    }
}
