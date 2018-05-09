namespace GuestBook.Services.ViewModels
{
    public class AddEvaluationModel
    {
        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Оценка комментария
        /// </summary>
        public bool IsPlus { get; set; }
    }
}
