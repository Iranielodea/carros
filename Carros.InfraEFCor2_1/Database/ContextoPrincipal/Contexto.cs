using Carros.Dominio.Entidades;
using Carros.InfraEFCor2_1.Database.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Carros.InfraEFCor2_1.Database.ContextoPrincipal
{
    public class Contexto : DbContext
    {
        public DbSet<Marca> MarcaSet { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"database = 127.0.0.1 / 3050:C:\Projetos\DotNet\Carros\Banco\VEICULO.FDB; user = sysdba; password = rota11";
            string connectionString = @"database=127.0.0.1/3050:C:\Projetos\DotNet\Carros\Banco\VEICULO.FDB; user=sysdba; password=rota11";
            optionsBuilder.UseFirebird(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MarcaConfiguration());

            //modelo.Entity<Blog>(entity =>
            //{
            //    entity.HasIndex(e => e.BlogId)
            //        .HasName("Id")
            //        .IsUnique();
            //});

        }
    }
}
