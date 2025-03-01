using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DTOs.Domain;
using GraphQL;
using GraphQL.Types;
using GraphqlAPI.Types;

namespace GraphqlAPI.Mutations
{
    public class AuthorMutation:ObjectGraphType
    {
        public AuthorMutation(IAuthorService authorService)
        {
            Field<StringGraphType>("addAuthor")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }
            ))
            .Resolve(context =>
            {
                var authorInput = context.GetArgument<Author>("author");
                authorService.Add(authorInput);

                return "Author added successfully";
            });

            Field<StringGraphType>("deleteAuthor")
                .Arguments(new QueryArgument<IntGraphType> { Name = "id", Description = "id is required" })
                .Resolve(context =>
                {
                    var authorId = context.GetArgument<int>("id");
                    authorService.Delete(authorId);
                    return "Author deleted successfully";
                });
        }
    }
}
