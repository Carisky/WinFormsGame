using Microsoft.EntityFrameworkCore;
using WinFormsGame.db.models;

namespace WinFormsGame.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
