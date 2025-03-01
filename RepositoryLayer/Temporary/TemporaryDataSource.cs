using DTOs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Temporary
{
    public class TemporaryDataSource : ITemporaryDataSource
    {
        public TemporaryDataSource()
        {
            Books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "Bangla",
                    Description="Text book",
                    Pages = 200
                },
                new Book()
                {
                    Id = 2,
                    Name = "English",
                    Description="Additional grammar book",
                    Pages = 241
                }
            };
        }
        public List<Book> Books { get; set; }
    }
}
