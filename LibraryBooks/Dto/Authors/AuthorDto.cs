using AutoMapper;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto.Authors
{
    [AutoMap(typeof(Author), ReverseMap = true)]
    public class AuthorDto : EntityDto
    {
        public string Name { get; set; }
    }
}
