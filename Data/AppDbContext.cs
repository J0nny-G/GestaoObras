using Microsoft.EntityFrameworkCore;
using GestaoObras.Models;

namespace GestaoObras.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<ObraMaterial> ObrasMateriais { get; set; }
        public DbSet<ObraMaoDeObra> ObrasMaoDeObra { get; set; }
        public DbSet<ObraPagamento> ObrasPagamentos { get; set; }
        public DbSet<MovimentoStock> MovimentosStock { get; set; }
    }
}
