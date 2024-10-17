using Microsoft.EntityFrameworkCore;
using EmanuelGalindo_MariaFernandaMolinas_BancoDeDados.Models;

namespace EmanuelGalindo_MariaFernandaMolinas_BancoDeDados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Folha> Folhas { get; set; }
    }
}
