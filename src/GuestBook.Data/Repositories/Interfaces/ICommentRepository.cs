using GuestBook.Models;
using System.Threading.Tasks;

namespace GuestBook.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Добавляет комментарий
        /// </summary>
        Task AddComment(Comment comment);

        /// <summary>
        /// Добавляет оценку к комментарию
        /// </summary>
        Task AddEvaluation(EvaluationComment evaluation);

        /// <summary>
        /// Удаляет оценку к комментарию
        /// </summary>
        Task RemoveEvaluation(string id);
    }
}
