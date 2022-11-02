using AutoMapper;
using LibraryBooks.Core.Models;
using LibraryBooks.Dto;

namespace LibraryBooks.Mapping
{
    //  mapping profile
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>()
                .ForMember(m => m.Author, n => n.Ignore())
                .ForMember(m => m.Genre,  n => n.Ignore());
        }
    }
}
