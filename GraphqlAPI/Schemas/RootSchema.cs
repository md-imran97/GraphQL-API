using GraphQL.Types;
using GraphqlAPI.Mutations;
using GraphqlAPI.Queries;

namespace GraphqlAPI.Schemas
{
    public class RootSchema: Schema
    {
        public RootSchema(RootQuery rootQuery, AuthorMutation authorMutation)
        {
            Query = rootQuery;
            Mutation = authorMutation;
        }
    }
}
