namespace GuestBook.Services.ViewModels
{
    public class CommentViewModel
    {
        public string CommentId { get; set; }

        /// <summary>
        /// Полное имя автора комментария
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Описание комментария
        /// </summary>
        public string Description { get; set; }
    }
}
