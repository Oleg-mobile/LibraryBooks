using AutoMapper;
using LibraryBooks.Attributes;
using LibraryBooks.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBooks.Dto.Authors
{
    [AutoMap(typeof(Book), ReverseMap = true)]
    public class BookDto : EntityDto
    {
        [DgvColumn(DisplayName = "Пользователь", IsVisible = false)]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [DgvColumn(DisplayName = "Автор")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        [DgvColumn(DisplayName = "Жанр")]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        [DgvColumn(DisplayName = "Название")]
        public string Name { get; set; }
        [DgvColumn(DisplayName = "Издание", IsVisible = false)]
        public string Publication { get; set; }
        [DgvColumn(DisplayName = "Год выпуска", IsVisible = false)]
        public int Year { get; set; }
        [DgvColumn(DisplayName = "Закладка", IsVisible = false)]
        public int Mark { get; set; }
        [DgvColumn(DisplayName = "Количество страниц", IsVisible = false)]
        public int PageCount { get; set; }
        [DgvColumn(DisplayName = "Путь к книге")]
        public string PathToBook { get; set; }
        [DgvColumn(DisplayName = "Понравилась", IsVisible = false)]
        public bool IsLiked { get; set; }
        [DgvColumn(DisplayName = "Прочитана", IsVisible = false)]
        public bool IsFinished { get; set; }
    }
}
