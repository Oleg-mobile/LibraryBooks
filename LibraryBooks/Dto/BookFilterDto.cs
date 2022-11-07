namespace LibraryBooks.Dto
{
    public class BookFilterDto
    {
        public string Keyword { get; set; }
        public bool? IsLiked { get; set; }
        public bool? IsFinished { get; set; }
    }
}
