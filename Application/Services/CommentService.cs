using Application.Interfaces;
using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task DeleteComment(int id)
        {
            var result = await _commentRepository.getCommentById(id);

            if(result != null)
            {
                await _commentRepository.Delete(result);
                return;
            }

            throw new Exception("Невозможно удалить комменетарий");
        }

        public async Task Update(Comment comment)
        {
            var result = await _commentRepository.getCommentById(comment.id);

            if(result != null)
            {
                result.text = comment.text;
                await _commentRepository.Update(result);
                return;
            }

            throw new Exception("Невозможно обновить текст комментария");
        }

        public async Task<Comment> getCommentById(int id)
        {
            var result = await _commentRepository.getCommentById(id);

            return result == null ? throw new Exception("Нет коммента") : result;
        }

        public async Task<IEnumerable<Comment>> getComments()
        {
            var result = await _commentRepository.getComments();

            return result == null ? throw new Exception("У задачи нет комментариев") : result;
        }
    }
}
