using DataAccessLayer.Interfaces;
using DataAccessLayer.Temporary;
using DTOs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Temporary.Repositories
{
    public class TempBookRepository : IBookRepository
    {
        public List<Book> Entities { get; set; }
        public TempBookRepository(ITemporaryDataSource temporaryDataSource)
        {
            Entities = temporaryDataSource.Books;
        }
        public Book Get(int id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return Entities;
        }
        public void Add(Book book)
        {
            Entities.Add(book);
            
        }
        public void Update(Book book)
        {
            Entities[book.Id] = book;
           
        }
        public void Delete(int id)
        {
            Entities.RemoveAt(Entities.FindIndex(e => e.Id == id));
        }
    }
}
