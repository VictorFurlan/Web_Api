using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }
        public DbSet<Mpedido> LPedidos { get; set; }
        public DbSet<Status> LStatus { get; set; }
    }
}
