namespace GuestBook.Models
{
    /// <summary>
    /// Оценка комментария
    /// </summary>
    public class EvaluationComment
    {
        public string EvaluationCommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public string CommentId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// Оценка комментария. False - Дизлайк. True - Лайк
        /// </summary>
        public bool Evaluation { get; set; }
    }
}
