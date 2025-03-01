using DTOs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAuthorService: IBaseService<Author, int>
    {
        Author Get(int id);
        List<Author> GetAll();
        void Add(Author entity);
        void Update(int id, Author entity);
        void Delete(int id);
    }
}
