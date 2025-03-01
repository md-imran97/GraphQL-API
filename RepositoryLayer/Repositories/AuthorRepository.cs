using DataAccessLayer.Database;
using DataAccessLayer.Interfaces;
using DTOs.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseRepository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DataSourceContext dataSourceContext) : base(dataSourceContext)
        {
        }
    }
}
