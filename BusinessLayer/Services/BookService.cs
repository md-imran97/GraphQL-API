using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DTOs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public Book Get(int id)
        {
            return _mapper.Map<Book>(_bookRepository.Get(id));
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().Select(_mapper.Map<Book>).ToList();
        }
        public void Add(Book book)
        {
            _bookRepository.Add(_mapper.Map<DTOs.Persistence.Book>(book));

        }
        public void Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

    }
}
