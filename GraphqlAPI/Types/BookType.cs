using DTOs.Domain;
using GraphQL.Types;


namespace GraphqlAPI.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Description);
            Field(e => e.Pages);
            Field<AuthorType>("Author").Resolve(context => context.Source.Author);
        }
    }
}
