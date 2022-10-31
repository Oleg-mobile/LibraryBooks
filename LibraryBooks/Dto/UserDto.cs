using AutoMapper;
using LibraryBooks.Core.Models;

namespace LibraryBooks.Dto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserDto : EntityDto
    {
        public string Login { get; set; }
    }
}
