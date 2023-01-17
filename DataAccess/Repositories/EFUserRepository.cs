using DataAccess.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public EFUserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User> getUserById(int id) => await _context._user.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);

        public async Task CreateUser(User user)
        {
            _context._user.Add(user);

            await _context.SaveChangesAsync();
        }
    }
}
