using Microsoft.EntityFrameworkCore;

namespace PT_SalasDario.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public MyDbContext()
            : base()
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Domicilio> Domicilio { get; set; }
    }
}
