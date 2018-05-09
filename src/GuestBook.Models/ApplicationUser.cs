using Microsoft.AspNetCore.Identity;

namespace GuestBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FullName { get; set; }
    }
}
