using DTOs.Domain;
using GraphQL.Types;

namespace GraphqlAPI.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(a => a.Name);
            Field(a => a.Id);
            Field(a => a.Address);
            Field<ListGraphType<BookType>>("books").Resolve(context => context.Source.Books);
        }
    }
}
