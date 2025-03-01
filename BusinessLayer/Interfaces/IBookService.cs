using DTOs.Domain;

namespace BusinessLayer.Interfaces
{
    public interface IBookService:IBaseService<Book,int>
    {
        Book Get(int id);
        List<Book> GetAll();
        void Add(Book entity);
        void Update(Book entity);
        void Delete(int id);
    }
}
