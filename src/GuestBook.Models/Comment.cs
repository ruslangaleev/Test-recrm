namespace GuestBook.Models
{
    public class Comment
    {
        public string CommentId { get; set; }

        /// <summary>
        /// Описание комментария
        /// </summary>
        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
