using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> getComments();
        Task<Comment> getCommentById(int id);
        Task Update(Comment comment);
        Task DeleteComment(int id);
    }
}
