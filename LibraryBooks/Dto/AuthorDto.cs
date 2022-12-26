using AutoMapper;
using LibraryBooks.Attributes;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto
{
    [AutoMap(typeof(Author), ReverseMap = true)]  // Сравнить Author с AuthorDto
    public class AuthorDto : EntityDto
    {
        [DgvColumn(DisplayName = "Имя автора")]
        public string Name { get; set; }
    }
}
