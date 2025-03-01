using DTOs.Domain;
using GraphQL.Types;

namespace GraphqlAPI.Types
{
    public class AuthorInputType:InputObjectGraphType<Author>
    {
        public AuthorInputType()
        {
            Field(a => a.Name);
            Field(a => a.Address);
        }
    }
}
