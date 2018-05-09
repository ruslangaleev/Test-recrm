using System.Threading.Tasks;
using GuestBook.Data.Infrastructure;
using GuestBook.Data.Repositories.Interfaces;
using GuestBook.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GuestBook.Data.Repositories.Logic
{
    /// <summary>
    /// Репозиторий для комментариев
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        private readonly DbSet<Comment> _comments;

        private readonly DbSet<EvaluationComment> _evaluationComments;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CommentRepository(IStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(IStorage));
            }

            var context = storage as ApplicationDbContext;
            _comments = context.Comments;
            _evaluationComments = context.EvaluationComments;
        }

        /// <summary>
        /// Добавляет комментарий
        /// </summary>
        public async Task AddComment(Comment comment)
        {
            await _comments.AddAsync(comment);
        }

        /// <summary>
        /// Добавляет оценку к комментарию
        /// </summary>
        public async Task AddEvaluation(EvaluationComment evaluation)
        {
            await _evaluationComments.AddAsync(evaluation);
        }

        /// <summary>
        /// Удаляет оценку к комментарию
        /// </summary>
        public async Task RemoveEvaluation(string id)
        {
            var entry = await _evaluationComments.FindAsync(id);
            if (entry != null)
            {
                _evaluationComments.Remove(entry);
            }
        }
    }
}
