using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserTask> _userTask { get; set; }

        public DbSet<User> _user { get; set; }

        public DbSet<Status> _status { get; set; }

        public DbSet<Comment> _comment { get; set; }
    }
}
