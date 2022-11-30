using AutoMapper;
using LibraryBooks.Core.Models;
using LibraryBooks.Dto;

namespace LibraryBooks.Mapping
{
    //  mapping profile
    public class EntityToDtoProfile : Profile
    {
        // TODO нужно ли создать профиль для ридера
        public EntityToDtoProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>()
                .ForMember(m => m.Author, n => n.Ignore())
                .ForMember(m => m.Genre,  n => n.Ignore());
        }
    }
}
