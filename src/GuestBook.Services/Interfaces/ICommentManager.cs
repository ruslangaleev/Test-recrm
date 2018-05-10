using GuestBook.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestBook.Services.Interfaces
{
    public interface ICommentManager
    {
        /// <summary>
        /// Возвращает список комментариев
        /// </summary>
        Task<IEnumerable<CommentViewModel>> GetComments();

        /// <summary>
        /// Добавляет комментарий
        /// </summary>
        Task AddComment(AddCommentModel model);

        /// <summary>
        /// Обновляет оценку у комментарию
        /// </summary>
        Task UpdateEvaluation(AddEvaluationModel model);
    }
}
