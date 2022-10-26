using AutoMapper;
using LibraryBooks.Attributes;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto.Authors
{
    [AutoMap(typeof(Genre), ReverseMap = true)]
    public class GenreDto : EntityDto
    {
        [DgvColumn(DisplayName = "Название жанра")]
        public string Name { get; set; }
    }
}
