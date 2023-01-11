namespace LibraryBooks.Core.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }  // Используется для шифрования пароля
    }
}
