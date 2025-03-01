using GraphQL.Types;

namespace GraphqlAPI.Queries
{
    public class RootQuery: ObjectGraphType
    {
        public RootQuery(BookQuery bookQuery, AuthorQuery authorQuery)
        {
            AddField(bookQuery.GetField("BookById"));
            AddField(bookQuery.GetField("Books"));
            AddField(authorQuery.GetField("AuthorById"));
            AddField(authorQuery.GetField("Authors"));
        }

        
    }
}
