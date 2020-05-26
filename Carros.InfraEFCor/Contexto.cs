using Carros.Dominio.Entidades;
using Carros.InfraEFCor.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Carros.InfraEFCor
{
    public class Contexto : DbContext
    {
        public DbSet<Marca> MarcaSet { get; set; }
        public DbSet<TabControle> TabControleSet { get; set; }
        public DbSet<Generator> GeneratorSet { get; set; }
        public DbSet<Usuario> UsuarioSet { get; set; }
        public DbSet<CadEncontro> CadEncontroSet { get; set; }
        public DbSet<Cidade> CidadeSet { get; set; }
        public DbSet<Profissao> ProfissaoSet { get; set; }
        public DbSet<Veiculo> VeiculoSet { get; set; }

        // para ativar o LazyLoad
        // executar no dos o comando:
        // 1) dotnet add package Microsoft.EntityFrameworkCore.Proxies
        // 2) using Microsoft.EntityFrameworkCore.Proxies;
        // 3) optionsBuilder.UseLazyLoadingProxies();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseFirebird(@"database=127.0.0.1/3050:C:\Projetos\DotNet\Carros\Banco\VEICULO.FDB;user=sysdba;password=rota11");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new TabControleMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CadEncontroMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ProfissaoMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
        }
    }
}
