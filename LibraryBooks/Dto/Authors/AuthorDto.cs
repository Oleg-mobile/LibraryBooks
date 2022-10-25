using AutoMapper;
using LibraryBooks.Attributes;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto.Authors
{
    [AutoMap(typeof(Author), ReverseMap = true)]  // compare Author with AuthorDto
    public class AuthorDto : EntityDto
    {
        [DgvColumn(DisplayName = "Имя автора")]
        public string Name { get; set; }
    }
}
