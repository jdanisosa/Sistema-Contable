using Microsoft.EntityFrameworkCore;
using Sistema_Contable.Models;

namespace Sistema_Contable.DB

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Grupo_Contable> Grupo_Contables { get; set; }
        public DbSet<Clasificacion_Grupo> Clasificacion_Grupos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Partida_Diario> Partida_Diarios { get; set; }
        public DbSet<Detalle_Partida_Diario> Detalle_Partida_Diarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalle_Partida_Diario>(entity =>
            {
                entity.HasKey(e => new { e.Id_Cuenta, e.Id_Partida });
            });
        }
    }
}
