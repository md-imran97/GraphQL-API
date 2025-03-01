using DTOs.Persistence;

namespace DataAccessLayer.Temporary
{
    public interface ITemporaryDataSource
    {
        public List<Book> Books { get; set; }
    }
}