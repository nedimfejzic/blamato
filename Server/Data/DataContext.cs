using Microsoft.EntityFrameworkCore;

namespace blamato.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Pomodoro> Pomodoros{ get; set; }
    }
}
