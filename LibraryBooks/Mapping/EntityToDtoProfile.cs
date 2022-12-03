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
            CreateMap<Book, BookDto>().ForMember(m => m.ReaderName, m => m.MapFrom(n => n.Reader == null ? "Читалка не задана!" : n.Reader.Name));
            CreateMap<BookDto, Book>()
                .ForMember(m => m.Author, n => n.Ignore())
                .ForMember(m => m.Genre,  n => n.Ignore())
                .ForMember(m => m.Reader, n => n.Ignore());
        }
    }
}
