using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DTOs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Temporary.Services
{
    public class TempBookService:IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private static int BookId { get; set; }

        public TempBookService(IBookRepository bookRepository, IMapper mapper)
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
            book.Id = BookId;
            BookId++;
             _bookRepository.Add(_mapper.Map<DTOs.Persistence.Book>(book));
            
        }
        public void Update(Book book)
        {
           _bookRepository.Update(_mapper.Map<DTOs.Persistence.Book>(book));
           
        }
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
