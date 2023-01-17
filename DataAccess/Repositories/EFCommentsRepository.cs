using DataAccess.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EFCommentsRepository : ICommentRepository
    {
        private ApplicationDbContext _context;

        public EFCommentsRepository(ApplicationDbContext context) => _context = context;

        public async Task Delete(Comment comment)
        {
            _context._comment.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> getComments() => await _context._comment.ToListAsync();

        public async Task<Comment> getCommentById(int id) => await _context._comment.FirstOrDefaultAsync();

        public async Task Update(Comment comment)
        {
            _context._comment.Update(comment);
            await _context.SaveChangesAsync();
        }
    }
}
