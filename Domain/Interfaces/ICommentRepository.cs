using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> getComments();

        Task Delete(Comment comment);

        Task Update(Comment comment);

        Task<Comment> getCommentById(int id);
    }
}
