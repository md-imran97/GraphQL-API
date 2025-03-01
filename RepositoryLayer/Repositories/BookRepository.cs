using DataAccessLayer.Database;
using DataAccessLayer.Interfaces;
using DTOs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public BookRepository(DataSourceContext dataSourceContext):base(dataSourceContext)
        {
            
        }
    }
}
