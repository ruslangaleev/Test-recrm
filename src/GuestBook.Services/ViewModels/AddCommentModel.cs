namespace GuestBook.Services.ViewModels
{
    public class AddCommentModel
    {
        /// <summary>
        /// Описание комментария
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Автор комментария
        /// </summary>
        public string AuthorId { get; set; }
    }
}
