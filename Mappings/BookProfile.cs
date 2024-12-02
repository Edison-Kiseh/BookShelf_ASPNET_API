using aspnet.DTO;
using aspnet.Models;
using AutoMapper;

namespace aspnet.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookWriteDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}