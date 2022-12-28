using AutoMapper;
using LibraryBooks.Core.Models;
using LibraryBooks.Dto;

namespace LibraryBooks.Mapping
{
    // Профиль маппинга
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Book, BookDto>().ForMember(m => m.ReaderName, m => m.MapFrom(n => n.Reader == null ? "" : n.Reader.Name));  // реакция на null в таблице
            CreateMap<BookDto, Book>()
                .ForMember(m => m.Author, n => n.Ignore())
                .ForMember(m => m.Genre,  n => n.Ignore())
                .ForMember(m => m.Reader, n => n.Ignore());
        }
    }
}
