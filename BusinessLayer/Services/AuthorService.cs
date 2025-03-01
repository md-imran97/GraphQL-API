using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DTOs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Author Get(int id)
        {
            return _mapper.Map<Author>(_authorRepository.Get(id));
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll().Select(_mapper.Map<Author>).ToList();
        }
        public void Add(Author entity)
        {
            _authorRepository.Add(_mapper.Map<DTOs.Persistence.Author>(entity));
        }

        public void Update(int id, Author entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

    }
}
