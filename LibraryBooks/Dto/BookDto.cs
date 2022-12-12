using LibraryBooks.Attributes;

namespace LibraryBooks.Dto
{
    public class BookDto : EntityDto
    {
        [DgvColumn(DisplayName = "Название")]
        public string Name { get; set; }

        [DgvColumn(DisplayName = "Автор")]
        public string AuthorName { get; set; }

        [DgvColumn(DisplayName = "Жанр")]
        public string GenreName { get; set; }

        [DgvColumn(DisplayName = "Издание", IsVisible = false)]
        public string Publication { get; set; }

        [DgvColumn(DisplayName = "Год выпуска", IsVisible = false)]
        public int? Year { get; set; }

        [DgvColumn(DisplayName = "Закладка")]
        public int Mark { get; set; }

        [DgvColumn(DisplayName = "Количество страниц")]
        public int? PageCount { get; set; }

        [DgvColumn(DisplayName = "Путь к книге", IsVisible = false)]
        public string PathToBook { get; set; }

        [DgvColumn(DisplayName = "Путь к обложке", IsVisible = false)]
        public string PathToCover { get; set; }

        [DgvColumn(DisplayName = "Понравилась")]
        public bool IsLiked { get; set; }

        [DgvColumn(DisplayName = "Прочитана")]
        public bool IsFinished { get; set; }

        [DgvColumn(DisplayName = "Читалка")]
        public string ReaderName { get; set; }
    }
}
