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
    public class EFUserTaskRepository : IUserTaskRepository
    {
        private ApplicationDbContext _context;

        public EFUserTaskRepository(ApplicationDbContext context) => _context = context;

        public async Task Delete(UserTask task)
        {
            _context._userTask.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserTask>> getUserTask() => await _context._userTask.ToListAsync();

        public async Task<UserTask> getUserTaskById(int id) => await _context._userTask.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);

        public async Task Update(UserTask userTask)
        {
            _context._userTask.Update(userTask);
            await _context.SaveChangesAsync();
        }

        public async Task Create(UserTask task)
        {
            _context._userTask.Add(task);
            await _context.SaveChangesAsync();
        }
    }
}
