using Microsoft.EntityFrameworkCore;

namespace RGBViagens.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<ComprarDestinos> ComprarDestinos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Destinos> Destinos { get; set; }
    }
}
