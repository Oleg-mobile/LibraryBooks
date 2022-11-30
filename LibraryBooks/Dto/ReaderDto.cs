using AutoMapper;
using LibraryBooks.Attributes;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto
{
    [AutoMap(typeof(Reader), ReverseMap = true)]
    public class ReaderDto : EntityDto
    {
        [DgvColumn(DisplayName = "Название")]
        public string Name { get; set; }

        [DgvColumn(DisplayName = "Путь к читалке", IsVisible = false)]
        public string PathToReader { get; set; }

        [DgvColumn(DisplayName = "Формат открытия", IsVisible = false)]
        public string OpeningFormat { get; set; }

    }
}
