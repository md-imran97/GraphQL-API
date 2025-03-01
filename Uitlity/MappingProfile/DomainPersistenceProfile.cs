using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uitlity.MappingProfile
{
    public partial class DomainPersistenceProfile : Profile
    {
        public DomainPersistenceProfile()
        {
            //AddBookProfile();
            CreateMap<DTOs.Domain.Book, DTOs.Persistence.Book>().ReverseMap();
            CreateMap<DTOs.Domain.Author, DTOs.Persistence.Author>().ReverseMap();
        }
    }
}
