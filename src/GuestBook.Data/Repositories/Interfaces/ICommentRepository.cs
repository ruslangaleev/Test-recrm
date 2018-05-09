using GuestBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestBook.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Возвращает список комментарий
        /// </summary>
        Task<IEnumerable<Comment>> GetComments();

        /// <summary>
        /// Добавляет комментарий
        /// </summary>
        Task AddComment(Comment comment);

        /// <summary>
        /// Добавляет оценку к комментарию
        /// </summary>
        Task AddEvaluation(EvaluationComment evaluation);

        /// <summary>
        /// Редактирует оценку к комментарию
        /// </summary>
        Task UpdateEvaluation(EvaluationComment evaluation);

        /// <summary>
        /// Удаляет оценку к комментарию
        /// </summary>
        Task RemoveEvaluation(string id);

        /// <summary>
        /// Возвращает оценку к указанному комментарию
        /// </summary>
        Task<EvaluationComment> GetEvaluation(string commentId, string userId);
    }
}
