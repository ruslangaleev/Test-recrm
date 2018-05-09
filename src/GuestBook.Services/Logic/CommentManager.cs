using GuestBook.Data.Infrastructure.Interfaces;
using GuestBook.Data.Repositories.Interfaces;
using GuestBook.Models;
using GuestBook.Services.Interfaces;
using GuestBook.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestBook.Services.Logic
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(ICommentRepository commentRepository,
            IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(ICommentRepository));

            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        }

        public async Task AddComment(AddCommentModel model)
        {
            await _commentRepository.AddComment(new Comment
            {
                Description = model.Description,
                UserId = model.AuthorId
            });

            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<CommentViewModel>> GetComments()
        {
            var comments = await _commentRepository.GetComments();

            List<CommentViewModel> commentViewModels = new List<CommentViewModel>();
            foreach(var entry in comments)
            {
                commentViewModels.Add(new CommentViewModel
                {
                    CommentId = entry.CommentId,
                    FullName = entry.User.FullName,
                    Description = entry.Description
                });
            }

            return commentViewModels;
        }

        public async Task UpdateEvaluation(AddEvaluationModel model)
        {
            var evaluation = await _commentRepository.GetEvaluation(model.CommentId, model.UserId);

            if (evaluation == null)
            {
                await _commentRepository.AddEvaluation(new EvaluationComment
                {
                    CommentId = model.CommentId,
                    UserId = model.UserId,
                    IsPlus = model.IsPlus
                });
            }
            else
            {
                evaluation.IsPlus = model.IsPlus;
            }

            await _commentRepository.UpdateEvaluation(evaluation);
            await _unitOfWork.SaveChanges();
        }
    }
}
